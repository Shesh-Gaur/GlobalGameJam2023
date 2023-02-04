using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public struct HeldObject
{
    public GameObject gameObject;
    public Transform transform;
    public Rigidbody rb;
    public PhysicsProp propScript;
}

public class PlayerController : MonoBehaviour
{
    [Tooltip("Toggle Debug.Log Calls")]
    [SerializeField] protected bool debugPrint;

    //Controls
    PlayerControls controls;
    PlayerControls.OnFootActions onFoot;

    //Private Parameters
    float _verticalLook = 0; //The pitch of the camera.
    
    //States - We will switch to a state pattern... one day :(
    bool isGrounded;
    bool isCrouching;
    public bool isHoldingObject;

    RaycastHit hit;
    bool _hitLanded;

    RaycastHit clamberHit;

    //Refernce to the object we hold, gravity gun style
    HeldObject _heldObject;

    #region Cereal
    //Components
    [Header("Component References")]
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] GameObject _camera;
    [SerializeField] GameObject _groundCheck;
    [SerializeField] CapsuleCollider _capsuleCollider;

    //Player Parameters
    [Header("Movement Attributes")]

    [Tooltip("The base player movement speed when running.")]
    [SerializeField] float _movementSpeed = 4000f;

    [Tooltip("A multiplier applied when the player attempts to move when in the air.")]
    [SerializeField] float _airSpeed = 0.2f;

    [Tooltip("Turn Speed. Modify personal sensitivity from the IA Asset's Scale Processor.")]
    [SerializeField] float _lookSensitivity = 100f;

    [Tooltip("The force the player can jump with. Will result in less height as the player becomes heavier.")]
    [SerializeField] float _jumpForce = 100f;

    [Tooltip("The layers the groundcheck raycast will check with to determine if the player can jump.")]
    [SerializeField] LayerMask _groundCheckLayerMask;

    [Tooltip("The offset from the player position for the clamber raycast")]
    [SerializeField] Vector3 clamberRaycastOffset;

    [Tooltip("The distance of the clamber raycast. Updated automatically in OnValidate().")]
    [SerializeField] float clamberRaycastMaxDistance;

    [Header("Interaction Attributes")]
    
    [Tooltip("The distance the player can interact with elements of the world.")]
    [SerializeField] float _interactionDistance = 3f;

    [Header("\"Gravity Gun\" Attributes")]

    [Tooltip("The distance at which physics objects are held.")]
    [SerializeField] float _heldObjectDistance = 2.0f;

    [Tooltip("The force used to grab objects and hold them in front of the player.")]
    [SerializeField] float _grabForce = 10f;

    [Tooltip("The force with which held items are thrown.")]
    [SerializeField] float _throwForce = 100f;
    #endregion

    #region Player Actions

    private void Move()
    {
        Vector2 input = onFoot.Move.ReadValue<Vector2>();
        Vector3 force = transform.right * input.x + transform.forward * input.y;
        force = force * _movementSpeed * Time.deltaTime;
        if (!isGrounded)
        {
            force *= _airSpeed;
        }

        _rigidbody.AddForce(force);
    }

    private void Look()
    {
        Vector2 input = onFoot.Look.ReadValue<Vector2>() * _lookSensitivity * Time.deltaTime;

        //Horizontal Rotation of player GameObject
        transform.Rotate(Vector3.up, input.x);

        //Vertical Rotation of child Camera GameObject
        _verticalLook -= input.y;
        _verticalLook = Mathf.Clamp(_verticalLook, -89f, 89f);
        _camera.transform.localRotation = Quaternion.Euler(_verticalLook, 0, 0);
    }

    private void Jump()
    {
        if(isGrounded)
        {
            _rigidbody.AddForce(transform.up * _jumpForce);
        }
    }

    private void Crouch()
    {
        if (isCrouching)
        {
            isCrouching = false;
            transform.localScale = Vector3.one;
        }
        else
        {
            isCrouching = true;
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
    }

    private void Interact()
    {
        if(isHoldingObject)
        {
            releaseObject();
        }
        else if (_hitLanded)
        {
            if (hit.transform.CompareTag("WorldEntity"))
            {
                WorldEntity lookAtObj = hit.transform.gameObject.GetComponent<WorldEntity>();
                lookAtObj.PrintInteractionString();
                lookAtObj.Interact(this);
            }
        }
    }

    private void Fire()
    {
        if (isHoldingObject)
        {
            releaseObject();
            _heldObject.rb.AddForce(_camera.transform.forward * _throwForce, ForceMode.Impulse);
            //We're gonna expand this function to work for guns in the future.
            return;
        }
    }

    private void Clamber()
    {
        if (!isGrounded)
        {
            Vector3 clamberRaycastOrigin = transform.position + transform.TransformVector(clamberRaycastOffset);

            if (Physics.Raycast(clamberRaycastOrigin, Vector3.down, out clamberHit, clamberRaycastMaxDistance))
            {
                if (Vector3.Angle(clamberHit.normal, Vector3.up) < 45f)
                {
                    if (!Physics.Raycast(transform.position, Vector3.up, 1.75f, _groundCheckLayerMask))
                    {
                        transform.position = clamberHit.point + new Vector3(0f, 1.25f, 0f);
                    }
                }
            }
        }
    }

    #endregion

    #region Interal Use Functions

    //Grab the object the player is currently raycasting towards
    public void grabObject()
    {
        //Store the references to the grabbed object
        _heldObject.gameObject = hit.transform.gameObject;
        _heldObject.rb = _heldObject.gameObject.GetComponent<Rigidbody>();
        _heldObject.transform = _heldObject.gameObject.transform;
        _heldObject.propScript = _heldObject.gameObject.GetComponent<PhysicsProp>();
        isHoldingObject = true;
        //Let the object know we're holding it so that it can force us to drop it when broken
        _heldObject.propScript.AssignHolder(this);
        _heldObject.propScript.held = true;

        //Set the object's state to be ready for grabbing
        //_heldObject.rb.angularVelocity = Vector3.zero;
        //_heldObject.rb.useGravity = false;
        _heldObject.rb.isKinematic = true;
    }

    public void releaseObject()
    {
        //Drop the flag that updates held object updates
        isHoldingObject = false;
        _heldObject.rb.isKinematic = false;
        //Tell the prop it isn't being held anymore
        //This is so that if it breaks, it tells us to let go if we're holding something.
        _heldObject.propScript.held = false;
    }

    //Update breakdowns
    void heldObjectUpdate()
    {
        if (isHoldingObject)
        {
            Vector3 grabPos = transform.position + _camera.transform.forward * _heldObjectDistance;
            _heldObject.rb.MovePosition(Vector3.Lerp(_heldObject.transform.position, grabPos, Time.deltaTime * _grabForce));
            _heldObject.rb.MoveRotation(transform.rotation);
        }
    }

    #endregion

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Look();
        heldObjectUpdate();
        
        isGrounded = Physics.CheckSphere(_groundCheck.transform.position, 0.1f, _groundCheckLayerMask);

        //Raycast - What is the player looking at?
        _hitLanded = Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _interactionDistance);

        if(onFoot.Clamber.ReadValue<float>() > 0)
        {
            Clamber();
        }

        //Display Interaction String in the console
        if (_hitLanded)
        {
            WorldEntity ent = hit.transform.gameObject.GetComponent<WorldEntity>();
            if(ent != null)
            {
                if (debugPrint)
                {
                    ent.PrintInteractionString();
                }
            }
            else
            {
                if (debugPrint)
                {
                    Debug.Log("");
                }
            }
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        controls = new PlayerControls();
        onFoot = controls.onFoot;

        onFoot.Jump.performed += _ => Jump();
        onFoot.Crouch.performed += _ => Crouch();
        onFoot.Interact.performed += _ => Interact();
        onFoot.Clamber.performed += _ => Clamber();

        onFoot.Enable();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Reset()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main.gameObject;
        _groundCheck = GameObject.Find("GroundCheck");

        _movementSpeed = 80000;
        _airSpeed = 0.05f;
        _lookSensitivity = 100f;
        _jumpForce = 26460;
        _groundCheckLayerMask = LayerMask.GetMask("Environment");

        clamberRaycastOffset.x = 0f;
        clamberRaycastOffset.y = 1.75f; //Y - 1.25 To Player Head + 0.5 Arm Length Max
        clamberRaycastOffset.z = 0.5f; //Forward

        _interactionDistance = 3f;

        _heldObjectDistance = 2f;
        _grabForce = 150;
        _throwForce = 100;
    }

    private void OnValidate()
    {
        clamberRaycastMaxDistance = clamberRaycastOffset.y + 1f;
    }
}
