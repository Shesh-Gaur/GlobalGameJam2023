using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class TimeSplitter : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    [SerializeField] GameObject _camera;

    [SerializeField] bool inAltWorld = false;

    [SerializeField] Vector3 Offset;

    PlayerControls controls;
    PlayerControls.OnFootActions onFoot;

    bool cameraSwapped;

    private void Teleport()
    {
        Debug.Log("Teleporting");
        if(inAltWorld)
        {
            transform.position = transform.position - Offset;
            if (controller.isHoldingObject)
            {
                controller._heldObject.transform.position = controller._heldObject.transform.position - Offset;
            }
            inAltWorld = false;
        }
        else
        {
            transform.position = transform.position + Offset;
            if (controller.isHoldingObject)
            {
                controller._heldObject.transform.position = controller._heldObject.transform.position + Offset;
            }
            inAltWorld = true;
        }
    }

    void View()
    {
        if (inAltWorld)
        {
            if (!cameraSwapped)
            {
                _camera.transform.position = _camera.transform.position - Offset;
            }
            else
            {
                _camera.transform.position = _camera.transform.position + Offset;
            }
        }
        else
        {
            if (!cameraSwapped)
            {
                _camera.transform.position = _camera.transform.position + Offset;
            }
            else
            {
                _camera.transform.position = _camera.transform.position - Offset;
            }
        }
    }

    private void Awake()
    {
        controls = new PlayerControls();
        onFoot = controls.onFoot;

        onFoot.Swap.performed += _ => Teleport();

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

    void Reset()
    {
        Offset = new Vector3(0, 1000, 0);
    }

    void Update()
    {
        if(onFoot.View.ReadValue<float>() > 0 && !cameraSwapped)
        {
            View();
            cameraSwapped = true;
        }
        if(cameraSwapped && onFoot.View.ReadValue<float>() == 0)
        {
            View();
            cameraSwapped = false;
        }
    }
}
