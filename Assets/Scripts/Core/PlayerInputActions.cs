// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Core/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player Controls"",
            ""id"": ""34987beb-ecc1-4d6e-84e9-f23592057d81"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""16508c35-8af8-49cb-9d80-3b805e088b40"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""2b7a8dc6-a1a8-4381-810a-f7e94f88e9c4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action1"",
                    ""type"": ""Button"",
                    ""id"": ""8f1baa74-d619-4464-af60-ff44ebc2afff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action2"",
                    ""type"": ""Button"",
                    ""id"": ""55d9e3f3-5bcc-4171-8d56-fbb39d33d0ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""e4fb76c9-c28f-4d15-8294-5ed7adef5d08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTriggerAction"",
                    ""type"": ""Button"",
                    ""id"": ""4a71d337-2a7b-4f36-9092-251bc3a6943d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTriggerAction"",
                    ""type"": ""Button"",
                    ""id"": ""c6cc5bd7-adba-4b4f-af45-55b1940ba8e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5d5d722f-d83d-49ba-b590-57728613ddfd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""203c557a-1708-449e-862a-43e6acf91154"",
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
                    ""id"": ""cfb44631-fcdd-4c95-bac5-de92ee2bc343"",
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
                    ""id"": ""f4d57df4-e7e7-490d-af40-481456546749"",
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
                    ""id"": ""48fc4053-6d20-40f6-8742-79f727bcdc0b"",
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
                    ""id"": ""8d423f91-dc05-4544-b807-5ca1da08a50a"",
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
                    ""id"": ""c172183f-54ad-427e-af4b-bbed9c9990fd"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""3422129d-7553-44de-b42e-0f28a5f5961b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4cbe98e-140a-4f3b-aaf8-f59da2824d9e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6d2272b1-6f6f-4631-aed0-4efa16e8d793"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8394e339-4d3c-48d5-b437-f85eaeaea711"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d49a0a3d-b2c9-4b7c-a018-7b682d2d4aa0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""55738dd5-a761-45c8-ae9f-54737eff1f7b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee3db1cc-d64d-413d-ba3d-0da77117bb47"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abd9fbfe-5751-4cea-b79c-5b4780303b8c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69eeb752-0225-4e94-8bf0-d29d9a56c84c"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf7ed904-a34e-4c69-b5b2-00a1484cb00e"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31360859-afbb-4536-b6a6-0bc0c2e457e2"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7739431-ee83-4ac8-af19-6666e54ff9d4"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTriggerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82c54e35-aef4-4be4-8bf5-7357b551d8c6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTriggerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0df7280-f085-402a-8d53-c606b6b7397d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTriggerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f92af65-1482-4af3-af83-9ce921275248"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTriggerAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Controls
        m_PlayerControls = asset.FindActionMap("Player Controls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_Aim = m_PlayerControls.FindAction("Aim", throwIfNotFound: true);
        m_PlayerControls_Action1 = m_PlayerControls.FindAction("Action1", throwIfNotFound: true);
        m_PlayerControls_Action2 = m_PlayerControls.FindAction("Action2", throwIfNotFound: true);
        m_PlayerControls_Start = m_PlayerControls.FindAction("Start", throwIfNotFound: true);
        m_PlayerControls_LeftTriggerAction = m_PlayerControls.FindAction("LeftTriggerAction", throwIfNotFound: true);
        m_PlayerControls_RightTriggerAction = m_PlayerControls.FindAction("RightTriggerAction", throwIfNotFound: true);
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

    // Player Controls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_Aim;
    private readonly InputAction m_PlayerControls_Action1;
    private readonly InputAction m_PlayerControls_Action2;
    private readonly InputAction m_PlayerControls_Start;
    private readonly InputAction m_PlayerControls_LeftTriggerAction;
    private readonly InputAction m_PlayerControls_RightTriggerAction;
    public struct PlayerControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @Aim => m_Wrapper.m_PlayerControls_Aim;
        public InputAction @Action1 => m_Wrapper.m_PlayerControls_Action1;
        public InputAction @Action2 => m_Wrapper.m_PlayerControls_Action2;
        public InputAction @Start => m_Wrapper.m_PlayerControls_Start;
        public InputAction @LeftTriggerAction => m_Wrapper.m_PlayerControls_LeftTriggerAction;
        public InputAction @RightTriggerAction => m_Wrapper.m_PlayerControls_RightTriggerAction;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAim;
                @Action1.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction1;
                @Action1.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction1;
                @Action1.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction1;
                @Action2.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction2;
                @Action2.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction2;
                @Action2.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAction2;
                @Start.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnStart;
                @LeftTriggerAction.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLeftTriggerAction;
                @LeftTriggerAction.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLeftTriggerAction;
                @LeftTriggerAction.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLeftTriggerAction;
                @RightTriggerAction.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRightTriggerAction;
                @RightTriggerAction.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRightTriggerAction;
                @RightTriggerAction.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRightTriggerAction;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Action1.started += instance.OnAction1;
                @Action1.performed += instance.OnAction1;
                @Action1.canceled += instance.OnAction1;
                @Action2.started += instance.OnAction2;
                @Action2.performed += instance.OnAction2;
                @Action2.canceled += instance.OnAction2;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @LeftTriggerAction.started += instance.OnLeftTriggerAction;
                @LeftTriggerAction.performed += instance.OnLeftTriggerAction;
                @LeftTriggerAction.canceled += instance.OnLeftTriggerAction;
                @RightTriggerAction.started += instance.OnRightTriggerAction;
                @RightTriggerAction.performed += instance.OnRightTriggerAction;
                @RightTriggerAction.canceled += instance.OnRightTriggerAction;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnAction1(InputAction.CallbackContext context);
        void OnAction2(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnLeftTriggerAction(InputAction.CallbackContext context);
        void OnRightTriggerAction(InputAction.CallbackContext context);
    }
}
