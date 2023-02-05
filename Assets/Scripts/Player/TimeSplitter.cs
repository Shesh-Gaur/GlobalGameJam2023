using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Events;

public class TimeSplitter : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    [SerializeField] bool inAltWorld = false;

    [SerializeField] Vector3 Offset;

    PlayerControls controls;
    PlayerControls.OnFootActions onFoot;

    [SerializeField] UnityEvent _onSwitchTimelines;

    private void Teleport()
    {
        Debug.Log("Teleporting");
        _onSwitchTimelines?.Invoke();
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
}
