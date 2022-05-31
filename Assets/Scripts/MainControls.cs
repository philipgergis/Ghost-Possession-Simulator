//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Input Actions/MainControls.inputactions
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

public partial class @MainControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControls"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""fd499fb7-f7ff-4c88-8520-7ce0bb69d8b6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""18f93f5a-e182-47d6-bff8-ac68ee9935f4"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""2c5dd685-482f-4d6e-bac0-a443712e0d20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Possess"",
                    ""type"": ""Button"",
                    ""id"": ""234313dd-0bf6-43fc-899f-e3ec114cc3be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InventoryLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f37fd103-55fc-4b59-9abb-b91e7b46a29a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InventoryRight"",
                    ""type"": ""Button"",
                    ""id"": ""f87dea73-b994-44ee-bb21-ae086e5654ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""6d4ae7d3-0ae2-4296-8db8-1ae994c00a7b"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7d30db7d-2bf2-4c7e-9a25-82080172d534"",
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
                    ""id"": ""5fbcf3db-d435-4273-8822-6073f3144255"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""6ce4a00c-694b-4c4e-9212-f2b642e7dfab"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""bb9bc3e3-622e-46da-975a-8b5ea20b4f5e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f5dbf814-74b4-4e83-83c2-17f7bdcf9066"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b2580cb-fd53-4edd-9499-27e4ad1ecca7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Possess"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47943b97-cb09-4449-9ffb-34216041a1f8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acf62942-9f41-41d8-a051-627ef8460cc1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Ghost"",
            ""id"": ""7543b190-0417-4dbc-9412-ba83392d2cbc"",
            ""actions"": [
                {
                    ""name"": ""Fly"",
                    ""type"": ""Value"",
                    ""id"": ""f52c6c27-b43a-4777-81dd-f668b2ecc123"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Possess"",
                    ""type"": ""Button"",
                    ""id"": ""2f6ed6f1-529e-4ab5-8579-df5a1460870d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""1284f72e-d96c-4e2d-8c7b-03b6f3df971b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""7aeb475f-229b-4e56-8c3a-67fd0f97d85d"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""aa6566a8-3706-4bf7-b99d-99522f04ef40"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""91ef6d82-5d8e-4879-bd21-cfe64e4f8aee"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""71aca12d-0bfb-4243-b407-f852202cb2e2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Possess"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""066bf95f-48de-4667-97b6-f89b60a33e76"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Move = m_Main.FindAction("Move", throwIfNotFound: true);
        m_Main_Ability = m_Main.FindAction("Ability", throwIfNotFound: true);
        m_Main_Possess = m_Main.FindAction("Possess", throwIfNotFound: true);
        m_Main_InventoryLeft = m_Main.FindAction("InventoryLeft", throwIfNotFound: true);
        m_Main_InventoryRight = m_Main.FindAction("InventoryRight", throwIfNotFound: true);
        // Ghost
        m_Ghost = asset.FindActionMap("Ghost", throwIfNotFound: true);
        m_Ghost_Fly = m_Ghost.FindAction("Fly", throwIfNotFound: true);
        m_Ghost_Possess = m_Ghost.FindAction("Possess", throwIfNotFound: true);
        m_Ghost_Ability = m_Ghost.FindAction("Ability", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Move;
    private readonly InputAction m_Main_Ability;
    private readonly InputAction m_Main_Possess;
    private readonly InputAction m_Main_InventoryLeft;
    private readonly InputAction m_Main_InventoryRight;
    public struct MainActions
    {
        private @MainControls m_Wrapper;
        public MainActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Main_Move;
        public InputAction @Ability => m_Wrapper.m_Main_Ability;
        public InputAction @Possess => m_Wrapper.m_Main_Possess;
        public InputAction @InventoryLeft => m_Wrapper.m_Main_InventoryLeft;
        public InputAction @InventoryRight => m_Wrapper.m_Main_InventoryRight;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                @Ability.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAbility;
                @Possess.started -= m_Wrapper.m_MainActionsCallbackInterface.OnPossess;
                @Possess.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnPossess;
                @Possess.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnPossess;
                @InventoryLeft.started -= m_Wrapper.m_MainActionsCallbackInterface.OnInventoryLeft;
                @InventoryLeft.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnInventoryLeft;
                @InventoryLeft.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnInventoryLeft;
                @InventoryRight.started -= m_Wrapper.m_MainActionsCallbackInterface.OnInventoryRight;
                @InventoryRight.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnInventoryRight;
                @InventoryRight.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnInventoryRight;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
                @Possess.started += instance.OnPossess;
                @Possess.performed += instance.OnPossess;
                @Possess.canceled += instance.OnPossess;
                @InventoryLeft.started += instance.OnInventoryLeft;
                @InventoryLeft.performed += instance.OnInventoryLeft;
                @InventoryLeft.canceled += instance.OnInventoryLeft;
                @InventoryRight.started += instance.OnInventoryRight;
                @InventoryRight.performed += instance.OnInventoryRight;
                @InventoryRight.canceled += instance.OnInventoryRight;
            }
        }
    }
    public MainActions @Main => new MainActions(this);

    // Ghost
    private readonly InputActionMap m_Ghost;
    private IGhostActions m_GhostActionsCallbackInterface;
    private readonly InputAction m_Ghost_Fly;
    private readonly InputAction m_Ghost_Possess;
    private readonly InputAction m_Ghost_Ability;
    public struct GhostActions
    {
        private @MainControls m_Wrapper;
        public GhostActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fly => m_Wrapper.m_Ghost_Fly;
        public InputAction @Possess => m_Wrapper.m_Ghost_Possess;
        public InputAction @Ability => m_Wrapper.m_Ghost_Ability;
        public InputActionMap Get() { return m_Wrapper.m_Ghost; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GhostActions set) { return set.Get(); }
        public void SetCallbacks(IGhostActions instance)
        {
            if (m_Wrapper.m_GhostActionsCallbackInterface != null)
            {
                @Fly.started -= m_Wrapper.m_GhostActionsCallbackInterface.OnFly;
                @Fly.performed -= m_Wrapper.m_GhostActionsCallbackInterface.OnFly;
                @Fly.canceled -= m_Wrapper.m_GhostActionsCallbackInterface.OnFly;
                @Possess.started -= m_Wrapper.m_GhostActionsCallbackInterface.OnPossess;
                @Possess.performed -= m_Wrapper.m_GhostActionsCallbackInterface.OnPossess;
                @Possess.canceled -= m_Wrapper.m_GhostActionsCallbackInterface.OnPossess;
                @Ability.started -= m_Wrapper.m_GhostActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_GhostActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_GhostActionsCallbackInterface.OnAbility;
            }
            m_Wrapper.m_GhostActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fly.started += instance.OnFly;
                @Fly.performed += instance.OnFly;
                @Fly.canceled += instance.OnFly;
                @Possess.started += instance.OnPossess;
                @Possess.performed += instance.OnPossess;
                @Possess.canceled += instance.OnPossess;
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
            }
        }
    }
    public GhostActions @Ghost => new GhostActions(this);
    public interface IMainActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
        void OnPossess(InputAction.CallbackContext context);
        void OnInventoryLeft(InputAction.CallbackContext context);
        void OnInventoryRight(InputAction.CallbackContext context);
    }
    public interface IGhostActions
    {
        void OnFly(InputAction.CallbackContext context);
        void OnPossess(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
    }
}
