// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputHandler.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputHandler : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputHandler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputHandler"",
    ""maps"": [
        {
            ""name"": ""CameraControls"",
            ""id"": ""ae3f6e45-4b0e-43f3-878c-2fa202da4e26"",
            ""actions"": [
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""45eb1e4d-2380-4a1f-9aa6-c5473e846725"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""818b3114-b6f1-4217-b011-c1ddcd885c4a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActivateMouseLook"",
                    ""type"": ""Button"",
                    ""id"": ""2a59a5ff-1e2d-4044-8318-6038a449d0c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScreenPosition"",
                    ""type"": ""Value"",
                    ""id"": ""66ada724-6272-4516-a1b3-1d7f99a794da"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectSpectate"",
                    ""type"": ""Button"",
                    ""id"": ""bccfa200-83e7-4eb6-ac7e-6f13a1292367"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExitSpectate"",
                    ""type"": ""Button"",
                    ""id"": ""2c0a7888-81c0-4504-bf8a-7ff7ab87b5e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""284a9408-c9e5-47ca-b902-b20b5d37440d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""56e982e5-89b9-490d-bf11-4603cb5c7c3e"",
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
                    ""id"": ""09119473-fe36-47c9-a0fa-71395eb0571a"",
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
                    ""id"": ""a227890a-cbde-48a9-9be1-f31106478754"",
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
                    ""id"": ""4ae24795-2464-4a59-bef7-3d94fc8afe87"",
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
                    ""id"": ""c4c9fc21-6dfb-4333-9276-706e098e1cf4"",
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
                    ""id"": ""9e45d5da-dcf8-4263-a630-f7c72d42156c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateMouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""751c1bb3-d3c8-4422-91dd-e150bde3e7fd"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScreenPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c78c6a4-54d8-4d1d-85d1-2b1291d2c919"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSpectate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""509dd83c-b8c4-4f2b-8010-d7809db5552f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitSpectate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CameraControls
        m_CameraControls = asset.FindActionMap("CameraControls", throwIfNotFound: true);
        m_CameraControls_MouseLook = m_CameraControls.FindAction("MouseLook", throwIfNotFound: true);
        m_CameraControls_Movement = m_CameraControls.FindAction("Movement", throwIfNotFound: true);
        m_CameraControls_ActivateMouseLook = m_CameraControls.FindAction("ActivateMouseLook", throwIfNotFound: true);
        m_CameraControls_ScreenPosition = m_CameraControls.FindAction("ScreenPosition", throwIfNotFound: true);
        m_CameraControls_SelectSpectate = m_CameraControls.FindAction("SelectSpectate", throwIfNotFound: true);
        m_CameraControls_ExitSpectate = m_CameraControls.FindAction("ExitSpectate", throwIfNotFound: true);
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

    // CameraControls
    private readonly InputActionMap m_CameraControls;
    private ICameraControlsActions m_CameraControlsActionsCallbackInterface;
    private readonly InputAction m_CameraControls_MouseLook;
    private readonly InputAction m_CameraControls_Movement;
    private readonly InputAction m_CameraControls_ActivateMouseLook;
    private readonly InputAction m_CameraControls_ScreenPosition;
    private readonly InputAction m_CameraControls_SelectSpectate;
    private readonly InputAction m_CameraControls_ExitSpectate;
    public struct CameraControlsActions
    {
        private @InputHandler m_Wrapper;
        public CameraControlsActions(@InputHandler wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLook => m_Wrapper.m_CameraControls_MouseLook;
        public InputAction @Movement => m_Wrapper.m_CameraControls_Movement;
        public InputAction @ActivateMouseLook => m_Wrapper.m_CameraControls_ActivateMouseLook;
        public InputAction @ScreenPosition => m_Wrapper.m_CameraControls_ScreenPosition;
        public InputAction @SelectSpectate => m_Wrapper.m_CameraControls_SelectSpectate;
        public InputAction @ExitSpectate => m_Wrapper.m_CameraControls_ExitSpectate;
        public InputActionMap Get() { return m_Wrapper.m_CameraControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICameraControlsActions instance)
        {
            if (m_Wrapper.m_CameraControlsActionsCallbackInterface != null)
            {
                @MouseLook.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMouseLook;
                @Movement.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMovement;
                @ActivateMouseLook.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnActivateMouseLook;
                @ActivateMouseLook.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnActivateMouseLook;
                @ActivateMouseLook.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnActivateMouseLook;
                @ScreenPosition.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnScreenPosition;
                @ScreenPosition.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnScreenPosition;
                @ScreenPosition.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnScreenPosition;
                @SelectSpectate.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnSelectSpectate;
                @SelectSpectate.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnSelectSpectate;
                @SelectSpectate.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnSelectSpectate;
                @ExitSpectate.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnExitSpectate;
                @ExitSpectate.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnExitSpectate;
                @ExitSpectate.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnExitSpectate;
            }
            m_Wrapper.m_CameraControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @ActivateMouseLook.started += instance.OnActivateMouseLook;
                @ActivateMouseLook.performed += instance.OnActivateMouseLook;
                @ActivateMouseLook.canceled += instance.OnActivateMouseLook;
                @ScreenPosition.started += instance.OnScreenPosition;
                @ScreenPosition.performed += instance.OnScreenPosition;
                @ScreenPosition.canceled += instance.OnScreenPosition;
                @SelectSpectate.started += instance.OnSelectSpectate;
                @SelectSpectate.performed += instance.OnSelectSpectate;
                @SelectSpectate.canceled += instance.OnSelectSpectate;
                @ExitSpectate.started += instance.OnExitSpectate;
                @ExitSpectate.performed += instance.OnExitSpectate;
                @ExitSpectate.canceled += instance.OnExitSpectate;
            }
        }
    }
    public CameraControlsActions @CameraControls => new CameraControlsActions(this);
    public interface ICameraControlsActions
    {
        void OnMouseLook(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnActivateMouseLook(InputAction.CallbackContext context);
        void OnScreenPosition(InputAction.CallbackContext context);
        void OnSelectSpectate(InputAction.CallbackContext context);
        void OnExitSpectate(InputAction.CallbackContext context);
    }
}
