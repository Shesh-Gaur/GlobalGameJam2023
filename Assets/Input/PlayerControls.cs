//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""onFoot"",
            ""id"": ""78fa1ddf-45a8-4b53-834f-9a7c164977f8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""86f4693c-9ca1-4763-9e26-5c6fad62e5e7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""18a77a48-c1c0-4e6d-a91b-4d4726a9efbf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""825c3a08-7588-4148-82d2-d9174e4dd540"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Clamber"",
                    ""type"": ""Button"",
                    ""id"": ""6aebc2d9-06db-4310-8ccd-c1b2a9afb4fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""6eaa46c0-4922-4c3d-b504-8e235cde9e65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""74a9eb64-5462-474a-a16f-f27bbff25247"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""f0e07fc5-008b-4d81-b619-87ca05c980ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""6c5bdcd0-c9eb-4aa6-b33b-053558b2a318"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""59edacd9-3796-4980-a6fe-6210d241d07e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""58a972a7-b036-4ac4-bc9c-7562ee3dedf6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""36e4d57b-4f2e-4704-88f6-4aa71cf36f8d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""178edd8b-2ad9-41fe-9d81-9d4f226c7171"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fc55d0f6-3ecf-44e1-9055-e5d95e7fc568"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dc2fcfef-ae23-4e20-848c-13b514aecfe2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5407cbd6-80c5-4cda-a456-82914b740a02"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clamber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9bb239c-ccfc-446b-8493-87f81b673514"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b0e6953-abbe-45c7-9113-1667b8d4ff0d"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b736095e-20c0-417d-b18c-5912abcf14b1"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false,invertY=false),ScaleVector2"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5264004e-8f07-4236-b40e-42b64bdfe4fd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""143301c8-9b83-410a-801e-1a03673ce279"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // onFoot
        m_onFoot = asset.FindActionMap("onFoot", throwIfNotFound: true);
        m_onFoot_Move = m_onFoot.FindAction("Move", throwIfNotFound: true);
        m_onFoot_Look = m_onFoot.FindAction("Look", throwIfNotFound: true);
        m_onFoot_Jump = m_onFoot.FindAction("Jump", throwIfNotFound: true);
        m_onFoot_Clamber = m_onFoot.FindAction("Clamber", throwIfNotFound: true);
        m_onFoot_Interact = m_onFoot.FindAction("Interact", throwIfNotFound: true);
        m_onFoot_Crouch = m_onFoot.FindAction("Crouch", throwIfNotFound: true);
        m_onFoot_Fire = m_onFoot.FindAction("Fire", throwIfNotFound: true);
        m_onFoot_Swap = m_onFoot.FindAction("Swap", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // onFoot
    private readonly InputActionMap m_onFoot;
    private IOnFootActions m_OnFootActionsCallbackInterface;
    private readonly InputAction m_onFoot_Move;
    private readonly InputAction m_onFoot_Look;
    private readonly InputAction m_onFoot_Jump;
    private readonly InputAction m_onFoot_Clamber;
    private readonly InputAction m_onFoot_Interact;
    private readonly InputAction m_onFoot_Crouch;
    private readonly InputAction m_onFoot_Fire;
    private readonly InputAction m_onFoot_Swap;
    public struct OnFootActions
    {
        private @PlayerControls m_Wrapper;
        public OnFootActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_onFoot_Move;
        public InputAction @Look => m_Wrapper.m_onFoot_Look;
        public InputAction @Jump => m_Wrapper.m_onFoot_Jump;
        public InputAction @Clamber => m_Wrapper.m_onFoot_Clamber;
        public InputAction @Interact => m_Wrapper.m_onFoot_Interact;
        public InputAction @Crouch => m_Wrapper.m_onFoot_Crouch;
        public InputAction @Fire => m_Wrapper.m_onFoot_Fire;
        public InputAction @Swap => m_Wrapper.m_onFoot_Swap;
        public InputActionMap Get() { return m_Wrapper.m_onFoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OnFootActions set) { return set.Get(); }
        public void SetCallbacks(IOnFootActions instance)
        {
            if (m_Wrapper.m_OnFootActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Clamber.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnClamber;
                @Clamber.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnClamber;
                @Clamber.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnClamber;
                @Interact.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnInteract;
                @Crouch.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnCrouch;
                @Fire.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnFire;
                @Swap.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnSwap;
                @Swap.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnSwap;
                @Swap.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnSwap;
            }
            m_Wrapper.m_OnFootActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Clamber.started += instance.OnClamber;
                @Clamber.performed += instance.OnClamber;
                @Clamber.canceled += instance.OnClamber;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Swap.started += instance.OnSwap;
                @Swap.performed += instance.OnSwap;
                @Swap.canceled += instance.OnSwap;
            }
        }
    }
    public OnFootActions @onFoot => new OnFootActions(this);
    public interface IOnFootActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnClamber(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSwap(InputAction.CallbackContext context);
    }
}
