// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Radi/Action Map.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ActionMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Action Map"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""e7511477-af10-493a-9eee-16458e71dbbe"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""44800e36-fde4-4dc2-85fe-c2a84833aebe"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Value"",
                    ""id"": ""db74e95d-d53e-403a-8161-2fb810de3592"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""00b04c59-e77a-421e-8f92-2187251d1440"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Control"",
                    ""type"": ""Button"",
                    ""id"": ""3cf54f43-e9fc-4a2f-a057-96861f695e32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Duck"",
                    ""type"": ""Value"",
                    ""id"": ""bd0b99a0-e547-409e-aab4-f8555be2dd8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""891ac85b-8d2f-44ec-b92e-46c790aaf346"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mark"",
                    ""type"": ""Button"",
                    ""id"": ""f7d80c2a-d292-43e4-9c6e-e2f236dcd5e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""379c4cd3-c5e1-40ac-94e7-a573851edf70"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""262ea20c-a893-483f-832c-012fe143fd13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrows"",
                    ""id"": ""1236fe3d-8908-4b49-b1b5-fe93144367f9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""be8f5646-1b8f-480d-9b43-70960d32e8b8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bb2ab9bf-4e48-4177-a0d1-9fc2bafd761a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""db461989-be1e-4c53-8069-c82dd44a6920"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f9866c70-cc75-497f-af0d-5eb0c15f8ddc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""353cd5d4-0303-4956-aacf-245e04f13d41"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b3c9bc0f-3597-4074-b286-4fd938527ca8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea7374ca-937f-41a5-a75c-1c3bcbe8fba1"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""0d927c7d-1a8c-4bd1-924b-cc79049059a0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d16f8a4c-6077-49b9-8d03-c8727e45aa98"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ba19d794-c924-4f32-914c-93ace4f15e04"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""42627a3a-ab2a-4786-af33-2589d9424773"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a716967d-9696-48cc-804e-633690209b64"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""438cb932-c17d-4b0a-bbc0-78279f00d916"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""65a42f77-1c52-4d8e-ab2c-33ee75ac0903"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18368f7a-0abf-467b-a8d2-6da6a49678cf"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e005412-a73f-46fe-a97b-060d41077b27"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4ac5595-a17c-475e-a45b-7e9423a4e5cb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da8f1add-8e30-42e9-99c8-918b7067f1cd"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Horizontal = m_Gameplay.FindAction("Horizontal", throwIfNotFound: true);
        m_Gameplay_Vertical = m_Gameplay.FindAction("Vertical", throwIfNotFound: true);
        m_Gameplay_Space = m_Gameplay.FindAction("Space", throwIfNotFound: true);
        m_Gameplay_SwitchControl = m_Gameplay.FindAction("Switch Control", throwIfNotFound: true);
        m_Gameplay_Duck = m_Gameplay.FindAction("Duck", throwIfNotFound: true);
        m_Gameplay_Enter = m_Gameplay.FindAction("Enter", throwIfNotFound: true);
        m_Gameplay_Mark = m_Gameplay.FindAction("Mark", throwIfNotFound: true);
        m_Gameplay_MousePosition = m_Gameplay.FindAction("MousePosition", throwIfNotFound: true);
        m_Gameplay_Escape = m_Gameplay.FindAction("Escape", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Horizontal;
    private readonly InputAction m_Gameplay_Vertical;
    private readonly InputAction m_Gameplay_Space;
    private readonly InputAction m_Gameplay_SwitchControl;
    private readonly InputAction m_Gameplay_Duck;
    private readonly InputAction m_Gameplay_Enter;
    private readonly InputAction m_Gameplay_Mark;
    private readonly InputAction m_Gameplay_MousePosition;
    private readonly InputAction m_Gameplay_Escape;
    public struct GameplayActions
    {
        private @ActionMap m_Wrapper;
        public GameplayActions(@ActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Gameplay_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_Gameplay_Vertical;
        public InputAction @Space => m_Wrapper.m_Gameplay_Space;
        public InputAction @SwitchControl => m_Wrapper.m_Gameplay_SwitchControl;
        public InputAction @Duck => m_Wrapper.m_Gameplay_Duck;
        public InputAction @Enter => m_Wrapper.m_Gameplay_Enter;
        public InputAction @Mark => m_Wrapper.m_Gameplay_Mark;
        public InputAction @MousePosition => m_Wrapper.m_Gameplay_MousePosition;
        public InputAction @Escape => m_Wrapper.m_Gameplay_Escape;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVertical;
                @Space.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpace;
                @SwitchControl.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchControl;
                @SwitchControl.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchControl;
                @SwitchControl.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchControl;
                @Duck.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDuck;
                @Duck.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDuck;
                @Duck.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDuck;
                @Enter.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnter;
                @Mark.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMark;
                @Mark.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMark;
                @Mark.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMark;
                @MousePosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @Escape.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
                @SwitchControl.started += instance.OnSwitchControl;
                @SwitchControl.performed += instance.OnSwitchControl;
                @SwitchControl.canceled += instance.OnSwitchControl;
                @Duck.started += instance.OnDuck;
                @Duck.performed += instance.OnDuck;
                @Duck.canceled += instance.OnDuck;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
                @Mark.started += instance.OnMark;
                @Mark.performed += instance.OnMark;
                @Mark.canceled += instance.OnMark;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
        void OnSwitchControl(InputAction.CallbackContext context);
        void OnDuck(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
        void OnMark(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
