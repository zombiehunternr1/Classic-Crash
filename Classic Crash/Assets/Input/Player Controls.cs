// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player Controls.inputactions'

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
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Level"",
            ""id"": ""c0dcce23-0bf3-450e-bd41-43f9babc9c44"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fd78dae4-293c-4bf0-bd1f-a63c7fd5af2d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spin"",
                    ""type"": ""Button"",
                    ""id"": ""b92412d1-d83b-4fa9-9778-b07a6a7c176a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpPressed"",
                    ""type"": ""Button"",
                    ""id"": ""72d386c9-3580-4954-908e-95292caf6162"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""JumpReleased"",
                    ""type"": ""Button"",
                    ""id"": ""74fa1d11-55a6-436c-9bc7-eb19694080ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d49ae59d-cc85-4ab0-882d-22c66d461814"",
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
                    ""id"": ""8a48c338-0f63-4ebb-8dca-0738a9b18234"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""670724f0-c79b-453a-94dc-8d5ba3e3014d"",
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
                    ""id"": ""8287c948-19c8-44bd-b5ec-7be8acae7366"",
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
                    ""id"": ""744e7a73-8252-4d25-9b8e-f74bea5c5131"",
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
                    ""id"": ""c48cbc18-1f5a-4986-8f76-4d91b43299fb"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""01b7b47b-762f-4d64-a42e-2a4e81a75445"",
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
                    ""id"": ""53bfad33-381a-4096-9cff-a97afb43aa11"",
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
                    ""id"": ""f1c73bdf-e152-423f-ad9c-602c62671f92"",
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
                    ""id"": ""947b83bb-197a-4a08-a99b-8228214fbb86"",
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
                    ""id"": ""37bf5a8a-c1d3-4f5d-b601-3391691823e1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad/Joystick"",
                    ""id"": ""8b393abb-b67f-45dc-85f0-610e9c67d58e"",
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
                    ""id"": ""58119525-8a5f-4a75-b823-72bb6c0ffcb9"",
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
                    ""id"": ""686dd396-d85e-4150-b272-d70763370ea3"",
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
                    ""id"": ""ea43234f-bb80-4236-b95d-7f02eb9cef02"",
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
                    ""id"": ""aa7b9ba2-4812-4b69-a4de-5219693efb7d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad/D-Pad"",
                    ""id"": ""f985d42f-a0bc-4570-ba1b-623bdfc959e2"",
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
                    ""id"": ""8af0f93a-33d7-45e2-9200-ee9897bdd30b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2d59c545-5fd6-4fd3-af43-63aa24ce8c85"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ae03baeb-804e-4466-828e-64b4988fa19b"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7562f3c2-b702-42d9-9cec-fd7a9eb579f6"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""WorldMap"",
            ""id"": ""36530800-e26e-4fad-9253-8535cfcaf7cd"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""81ef7e75-db6c-4338-8f2e-665e64f3919d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""7a0dc998-88f0-48d3-a61c-5bb923f798c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""c3207d23-7970-4e0a-b910-986acb9e3c9a"",
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
                    ""id"": ""62512a30-68ba-4946-b1af-98e08f991637"",
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
                    ""id"": ""af874766-a066-4a9d-8ef7-d879cabe659e"",
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
                    ""id"": ""e0b2ea02-080a-46d2-82e9-2736cf5f49a4"",
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
                    ""id"": ""51bb96a8-a6eb-4b50-ae8e-c451dc78d4cd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad/Joystick"",
                    ""id"": ""441cbfb3-f530-4c67-be97-860cc675a806"",
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
                    ""id"": ""780e0d07-dfb5-473c-8edf-ad11b43ad872"",
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
                    ""id"": ""c31895ec-f36e-4377-a2ad-ca90d216a2cf"",
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
                    ""id"": ""601049db-6470-4889-829e-3b9204b12b5e"",
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
                    ""id"": ""910ddcf5-2280-4895-be58-5dfab1e8fa23"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad/D-pad"",
                    ""id"": ""930b5ed2-a285-4618-b4e7-adea6917c9c9"",
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
                    ""id"": ""3cebbb84-a686-41b0-acd6-8635db286998"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""23564005-94a9-4a1e-8e74-04aa1034f898"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d4bdbfd6-1b6b-461d-92b0-4a2ea511a83c"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""08e8ffb0-012e-4660-a6f1-f96be491b698"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6d5a23ed-f1c0-46e9-b89d-64396c5619af"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98d1dd4e-3d36-49a1-b9ab-9852639378bf"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Level
        m_Level = asset.FindActionMap("Level", throwIfNotFound: true);
        m_Level_Movement = m_Level.FindAction("Movement", throwIfNotFound: true);
        m_Level_Spin = m_Level.FindAction("Spin", throwIfNotFound: true);
        m_Level_JumpPressed = m_Level.FindAction("JumpPressed", throwIfNotFound: true);
        m_Level_JumpReleased = m_Level.FindAction("JumpReleased", throwIfNotFound: true);
        // WorldMap
        m_WorldMap = asset.FindActionMap("WorldMap", throwIfNotFound: true);
        m_WorldMap_Movement = m_WorldMap.FindAction("Movement", throwIfNotFound: true);
        m_WorldMap_Confirm = m_WorldMap.FindAction("Confirm", throwIfNotFound: true);
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

    // Level
    private readonly InputActionMap m_Level;
    private ILevelActions m_LevelActionsCallbackInterface;
    private readonly InputAction m_Level_Movement;
    private readonly InputAction m_Level_Spin;
    private readonly InputAction m_Level_JumpPressed;
    private readonly InputAction m_Level_JumpReleased;
    public struct LevelActions
    {
        private @PlayerControls m_Wrapper;
        public LevelActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Level_Movement;
        public InputAction @Spin => m_Wrapper.m_Level_Spin;
        public InputAction @JumpPressed => m_Wrapper.m_Level_JumpPressed;
        public InputAction @JumpReleased => m_Wrapper.m_Level_JumpReleased;
        public InputActionMap Get() { return m_Wrapper.m_Level; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LevelActions set) { return set.Get(); }
        public void SetCallbacks(ILevelActions instance)
        {
            if (m_Wrapper.m_LevelActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnMovement;
                @Spin.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnSpin;
                @Spin.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnSpin;
                @Spin.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnSpin;
                @JumpPressed.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnJumpPressed;
                @JumpPressed.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnJumpPressed;
                @JumpPressed.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnJumpPressed;
                @JumpReleased.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnJumpReleased;
                @JumpReleased.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnJumpReleased;
                @JumpReleased.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnJumpReleased;
            }
            m_Wrapper.m_LevelActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Spin.started += instance.OnSpin;
                @Spin.performed += instance.OnSpin;
                @Spin.canceled += instance.OnSpin;
                @JumpPressed.started += instance.OnJumpPressed;
                @JumpPressed.performed += instance.OnJumpPressed;
                @JumpPressed.canceled += instance.OnJumpPressed;
                @JumpReleased.started += instance.OnJumpReleased;
                @JumpReleased.performed += instance.OnJumpReleased;
                @JumpReleased.canceled += instance.OnJumpReleased;
            }
        }
    }
    public LevelActions @Level => new LevelActions(this);

    // WorldMap
    private readonly InputActionMap m_WorldMap;
    private IWorldMapActions m_WorldMapActionsCallbackInterface;
    private readonly InputAction m_WorldMap_Movement;
    private readonly InputAction m_WorldMap_Confirm;
    public struct WorldMapActions
    {
        private @PlayerControls m_Wrapper;
        public WorldMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_WorldMap_Movement;
        public InputAction @Confirm => m_Wrapper.m_WorldMap_Confirm;
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
                @Confirm.started -= m_Wrapper.m_WorldMapActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_WorldMapActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_WorldMapActionsCallbackInterface.OnConfirm;
            }
            m_Wrapper.m_WorldMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
            }
        }
    }
    public WorldMapActions @WorldMap => new WorldMapActions(this);
    public interface ILevelActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSpin(InputAction.CallbackContext context);
        void OnJumpPressed(InputAction.CallbackContext context);
        void OnJumpReleased(InputAction.CallbackContext context);
    }
    public interface IWorldMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
    }
}
