// GENERATED AUTOMATICALLY FROM 'Assets/InputMapping/Player/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Project2020
{
    public class @PlayerControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""9b513a72-8fe7-4023-bebd-e6c59748d76a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""af68e5a0-47b6-4374-9893-e70ae5cf1675"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Running"",
                    ""type"": ""Button"",
                    ""id"": ""aff0e870-93bb-4d47-97de-5af4d736100a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""aa0180fc-0d9e-4756-aad5-76d973779ad4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD "",
                    ""id"": ""d812eca1-5e47-4649-baab-9478cf97454c"",
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
                    ""id"": ""132eb460-9e0c-48c8-93a7-7b328203d668"",
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
                    ""id"": ""4efe4ad4-fe21-4cb1-8b43-c6665937cc1a"",
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
                    ""id"": ""a3c1f5fd-33c3-43d4-a1c0-edf509d08325"",
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
                    ""id"": ""daa32102-6d20-4e17-9286-c9d82d98d74e"",
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
                    ""id"": ""ee1c6973-5e1f-4adc-9a8a-933144478ea6"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9530284e-94b1-40a0-b832-7593479b5831"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""305c613c-5be3-4516-afb7-407341755789"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1c788f11-e8e4-44f5-b523-4a3555ec683f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""562ca9cd-73c5-4ae0-9491-98db627138e2"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CameraControls"",
            ""id"": ""08547371-bfb8-4c7d-908f-d5f1ed76fdd2"",
            ""actions"": [
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""3ea79b35-3b1e-4091-bf7a-330459dfcf62"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0b9de28d-de65-430b-b505-996f38a143ed"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
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
            m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
            m_Gameplay_Running = m_Gameplay.FindAction("Running", throwIfNotFound: true);
            m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
            // Interaction
            m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
            m_Interaction_Interact = m_Interaction.FindAction("Interact", throwIfNotFound: true);
            // CameraControls
            m_CameraControls = asset.FindActionMap("CameraControls", throwIfNotFound: true);
            m_CameraControls_Camera = m_CameraControls.FindAction("Camera", throwIfNotFound: true);
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
        private readonly InputAction m_Gameplay_Movement;
        private readonly InputAction m_Gameplay_Running;
        private readonly InputAction m_Gameplay_Jump;
        public struct GameplayActions
        {
            private @PlayerControls m_Wrapper;
            public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
            public InputAction @Running => m_Wrapper.m_Gameplay_Running;
            public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Running.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunning;
                    @Running.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunning;
                    @Running.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRunning;
                    @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Running.started += instance.OnRunning;
                    @Running.performed += instance.OnRunning;
                    @Running.canceled += instance.OnRunning;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);

        // Interaction
        private readonly InputActionMap m_Interaction;
        private IInteractionActions m_InteractionActionsCallbackInterface;
        private readonly InputAction m_Interaction_Interact;
        public struct InteractionActions
        {
            private @PlayerControls m_Wrapper;
            public InteractionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Interact => m_Wrapper.m_Interaction_Interact;
            public InputActionMap Get() { return m_Wrapper.m_Interaction; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
            public void SetCallbacks(IInteractionActions instance)
            {
                if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
                {
                    @Interact.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_InteractionActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                }
            }
        }
        public InteractionActions @Interaction => new InteractionActions(this);

        // CameraControls
        private readonly InputActionMap m_CameraControls;
        private ICameraControlsActions m_CameraControlsActionsCallbackInterface;
        private readonly InputAction m_CameraControls_Camera;
        public struct CameraControlsActions
        {
            private @PlayerControls m_Wrapper;
            public CameraControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Camera => m_Wrapper.m_CameraControls_Camera;
            public InputActionMap Get() { return m_Wrapper.m_CameraControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraControlsActions set) { return set.Get(); }
            public void SetCallbacks(ICameraControlsActions instance)
            {
                if (m_Wrapper.m_CameraControlsActionsCallbackInterface != null)
                {
                    @Camera.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnCamera;
                    @Camera.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnCamera;
                    @Camera.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnCamera;
                }
                m_Wrapper.m_CameraControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Camera.started += instance.OnCamera;
                    @Camera.performed += instance.OnCamera;
                    @Camera.canceled += instance.OnCamera;
                }
            }
        }
        public CameraControlsActions @CameraControls => new CameraControlsActions(this);
        public interface IGameplayActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnRunning(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface IInteractionActions
        {
            void OnInteract(InputAction.CallbackContext context);
        }
        public interface ICameraControlsActions
        {
            void OnCamera(InputAction.CallbackContext context);
        }
    }
}
