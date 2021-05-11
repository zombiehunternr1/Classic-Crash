// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""83b87d96-0126-4d68-b4a9-4ee775e38356"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f62dbad3-ae8a-4777-b36f-5935e47852bd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpPressed"",
                    ""type"": ""Button"",
                    ""id"": ""69dcc5cc-01a5-4d6a-8978-c7c362ce8e3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""JumpReleased"",
                    ""type"": ""Button"",
                    ""id"": ""2f02d0b6-5611-4ef8-a450-b450b518d3d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Spin"",
                    ""type"": ""Button"",
                    ""id"": ""25a26bb9-6d58-43b9-b67f-36ff6c649a95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""4c9da86c-e10f-445b-acfa-66ed979edcd4"",
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
                    ""id"": ""a766a086-5f05-49b3-8753-bbb2480bf83a"",
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
                    ""id"": ""1c473c21-c769-413e-af2c-21b64e83ebd8"",
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
                    ""id"": ""e09efc40-cce2-4f53-9828-ea58b8ce3c44"",
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
                    ""id"": ""5fd9d6c6-7207-474e-8916-1f367ec116e4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""81ba720a-505f-496b-ba78-37c8170e31e5"",
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
                    ""id"": ""bf8d742b-b1c9-4be6-9ec8-6d17123e29e8"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""279186d3-7b6a-464d-bd6f-09a5cb26884f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5d367b75-ddbb-49c5-88c5-82d1c205cb92"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""13022435-4aa8-409e-ab60-000fb78467a0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4e3d47ba-a3ff-40b4-87a4-ee2abf6ef19e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f90bbd42-f65c-4a45-b25d-808f940283e2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7c64db8-836c-4e10-95f6-07bae6d75817"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cfaffdc-2c43-425a-a8ed-58722302ff08"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09e84e8f-7f76-479d-82e2-202a6b21130f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a22f0e0-607e-4c15-85dc-6342b77ecbb4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""WorldMap"",
            ""id"": ""81f682e3-924e-4c61-b065-b4ab4456c317"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""82977681-f9c4-4fe1-a18a-2525a8602d6e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""f866947c-c7fa-48ab-b2fc-4200c3f6a39f"",
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
                    ""id"": ""6707bcca-9aa7-4385-881b-04861e45fc4b"",
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
                    ""id"": ""dccc91d4-d539-499e-89e9-87a0f8b95030"",
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
                    ""id"": ""093e9523-6447-45c0-bd6e-516c3fde13c3"",
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
                    ""id"": ""3f455357-2596-4bf9-b15f-73287eed3b94"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""f350c2a1-2f27-4198-824d-2334d4500f8f"",
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
                    ""id"": ""c00f9b4f-9062-4fff-80c1-da51be4b7fe1"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""15c3576c-812d-48b4-989f-40eba0d6ec4f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""62aa64be-3b9c-4c74-855f-f48a3e096174"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a32e5fcd-cb05-4481-92b1-5ed1fd222051"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_JumpPressed = m_Player.FindAction("JumpPressed", throwIfNotFound: true);
        m_Player_JumpReleased = m_Player.FindAction("JumpReleased", throwIfNotFound: true);
        m_Player_Spin = m_Player.FindAction("Spin", throwIfNotFound: true);
        // WorldMap
        m_WorldMap = asset.FindActionMap("WorldMap", throwIfNotFound: true);
        m_WorldMap_Movement = m_WorldMap.FindAction("Movement", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_JumpPressed;
    private readonly InputAction m_Player_JumpReleased;
    private readonly InputAction m_Player_Spin;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @JumpPressed => m_Wrapper.m_Player_JumpPressed;
        public InputAction @JumpReleased => m_Wrapper.m_Player_JumpReleased;
        public InputAction @Spin => m_Wrapper.m_Player_Spin;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @JumpPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPressed;
                @JumpPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPressed;
                @JumpPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpPressed;
                @JumpReleased.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpReleased;
                @JumpReleased.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpReleased;
                @JumpReleased.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpReleased;
                @Spin.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpin;
                @Spin.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpin;
                @Spin.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpin;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @JumpPressed.started += instance.OnJumpPressed;
                @JumpPressed.performed += instance.OnJumpPressed;
                @JumpPressed.canceled += instance.OnJumpPressed;
                @JumpReleased.started += instance.OnJumpReleased;
                @JumpReleased.performed += instance.OnJumpReleased;
                @JumpReleased.canceled += instance.OnJumpReleased;
                @Spin.started += instance.OnSpin;
                @Spin.performed += instance.OnSpin;
                @Spin.canceled += instance.OnSpin;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // WorldMap
    private readonly InputActionMap m_WorldMap;
    private IWorldMapActions m_WorldMapActionsCallbackInterface;
    private readonly InputAction m_WorldMap_Movement;
    public struct WorldMapActions
    {
        private @PlayerControls m_Wrapper;
        public WorldMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_WorldMap_Movement;
        public InputActionMap Get() { return m_Wrapper.m_WorldMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WorldMapActions set) { return set.Get(); }
        public void SetCallbacks(IWorldMapActions instance)
        {
            if (m_Wrapper.m_WorldMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_WorldMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_WorldMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_WorldMapActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_WorldMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public WorldMapActions @WorldMap => new WorldMapActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJumpPressed(InputAction.CallbackContext context);
        void OnJumpReleased(InputAction.CallbackContext context);
        void OnSpin(InputAction.CallbackContext context);
    }
    public interface IWorldMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
