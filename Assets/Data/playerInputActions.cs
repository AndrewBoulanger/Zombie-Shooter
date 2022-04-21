// GENERATED AUTOMATICALLY FROM 'Assets/Data/playerInputActions.inputactions'

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
    ""name"": ""playerInputActions"",
    ""maps"": [
        {
            ""name"": ""playerActionMap"",
            ""id"": ""a0fca6f7-b953-425a-8418-168451d6726b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c3a2e801-32b0-4857-b3e0-588003f95d34"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8b7a5b5c-c7d9-4a92-b075-0c3558b0e725"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""PassThrough"",
                    ""id"": ""976a4768-1932-4e9c-aba9-924c10ad6f7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""72bbb325-e34c-4a6a-bc32-69aa7a4330b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""582f0477-1dcc-4a27-8d2d-cd29eb6bfefe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelAiming"",
                    ""type"": ""PassThrough"",
                    ""id"": ""73f3b4eb-e316-4dbb-acd3-c3f09f1ba299"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""51363393-3229-445c-b919-ba812514a4dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""4b65d4e8-c404-430a-88ba-758e6256d601"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""AnyKey"",
                    ""type"": ""Button"",
                    ""id"": ""1f5539b9-fbf0-4a2b-86e1-9adece6f4511"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7ce6ceef-3954-45ad-94af-cf4c738934a8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""wasd"",
                    ""id"": ""7adcfc2c-af83-4fe8-a3e0-56532a688944"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0b30afb1-05dc-4db8-984b-5db434ee8bc4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f271be64-a9c5-4138-8ca7-f85b2fae92e8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0edcc376-e865-4668-8c2d-5181154e4d52"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e853ba01-6369-4f17-aaf3-51c1800a7705"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9b42f3f4-20ec-4231-9929-738d0d3f8877"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47efb86c-4536-4c37-a798-613ebd84861d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cc0f3c4-f0e7-4761-a69f-7601e16169c6"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9e1b42a-c713-4b89-b48b-3447cb739b5d"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8650c0b3-b202-4d60-bf2a-26317ecc93b3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91c0129c-f91f-467a-bfb3-722a6da07dec"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfae9945-6122-4a9f-a4f2-9e27e45799c1"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06325398-b62f-4cd0-91f0-a8fe50806569"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=10,y=10)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74f8a312-e5ab-49f1-9978-465aef19f629"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelAiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39050bfc-04c6-4e9e-90fc-c375fbf9d911"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelAiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77e331c2-2e31-4dda-882c-c714f499f850"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21972fbb-8ee4-4ac3-9125-f5de34ce4c7e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9e91694-1214-4208-8344-f91bce15b136"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe16b449-ee99-454c-b81a-979fcb33f397"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e45666b0-ea52-438c-aa39-c3c76e46e14b"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // playerActionMap
        m_playerActionMap = asset.FindActionMap("playerActionMap", throwIfNotFound: true);
        m_playerActionMap_Movement = m_playerActionMap.FindAction("Movement", throwIfNotFound: true);
        m_playerActionMap_Jump = m_playerActionMap.FindAction("Jump", throwIfNotFound: true);
        m_playerActionMap_Run = m_playerActionMap.FindAction("Run", throwIfNotFound: true);
        m_playerActionMap_Aim = m_playerActionMap.FindAction("Aim", throwIfNotFound: true);
        m_playerActionMap_Look = m_playerActionMap.FindAction("Look", throwIfNotFound: true);
        m_playerActionMap_CancelAiming = m_playerActionMap.FindAction("CancelAiming", throwIfNotFound: true);
        m_playerActionMap_Inventory = m_playerActionMap.FindAction("Inventory", throwIfNotFound: true);
        m_playerActionMap_Pause = m_playerActionMap.FindAction("Pause", throwIfNotFound: true);
        m_playerActionMap_AnyKey = m_playerActionMap.FindAction("AnyKey", throwIfNotFound: true);
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

    // playerActionMap
    private readonly InputActionMap m_playerActionMap;
    private IPlayerActionMapActions m_PlayerActionMapActionsCallbackInterface;
    private readonly InputAction m_playerActionMap_Movement;
    private readonly InputAction m_playerActionMap_Jump;
    private readonly InputAction m_playerActionMap_Run;
    private readonly InputAction m_playerActionMap_Aim;
    private readonly InputAction m_playerActionMap_Look;
    private readonly InputAction m_playerActionMap_CancelAiming;
    private readonly InputAction m_playerActionMap_Inventory;
    private readonly InputAction m_playerActionMap_Pause;
    private readonly InputAction m_playerActionMap_AnyKey;
    public struct PlayerActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_playerActionMap_Movement;
        public InputAction @Jump => m_Wrapper.m_playerActionMap_Jump;
        public InputAction @Run => m_Wrapper.m_playerActionMap_Run;
        public InputAction @Aim => m_Wrapper.m_playerActionMap_Aim;
        public InputAction @Look => m_Wrapper.m_playerActionMap_Look;
        public InputAction @CancelAiming => m_Wrapper.m_playerActionMap_CancelAiming;
        public InputAction @Inventory => m_Wrapper.m_playerActionMap_Inventory;
        public InputAction @Pause => m_Wrapper.m_playerActionMap_Pause;
        public InputAction @AnyKey => m_Wrapper.m_playerActionMap_AnyKey;
        public InputActionMap Get() { return m_Wrapper.m_playerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Aim.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnAim;
                @Look.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @CancelAiming.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnCancelAiming;
                @CancelAiming.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnCancelAiming;
                @CancelAiming.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnCancelAiming;
                @Inventory.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Pause.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPause;
                @AnyKey.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnAnyKey;
                @AnyKey.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnAnyKey;
                @AnyKey.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnAnyKey;
            }
            m_Wrapper.m_PlayerActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @CancelAiming.started += instance.OnCancelAiming;
                @CancelAiming.performed += instance.OnCancelAiming;
                @CancelAiming.canceled += instance.OnCancelAiming;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @AnyKey.started += instance.OnAnyKey;
                @AnyKey.performed += instance.OnAnyKey;
                @AnyKey.canceled += instance.OnAnyKey;
            }
        }
    }
    public PlayerActionMapActions @playerActionMap => new PlayerActionMapActions(this);
    public interface IPlayerActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnCancelAiming(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnAnyKey(InputAction.CallbackContext context);
    }
}
