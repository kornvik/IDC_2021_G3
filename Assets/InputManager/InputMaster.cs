// GENERATED AUTOMATICALLY FROM 'Assets/InputManager/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""a350f967-6278-4857-ae88-0696e8987e81"",
            ""actions"": [
                {
                    ""name"": ""Clock"",
                    ""type"": ""Button"",
                    ""id"": ""27d387d3-85e1-4b61-baf2-04920c6f1a2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CounterClock"",
                    ""type"": ""Button"",
                    ""id"": ""69b66bcd-9dce-4ec7-9bfe-b214cdfcf8f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a7f2a7c8-0ded-449e-8c35-3db22382c417"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d45cdc3e-125d-49d2-9683-7ebebbcdefa7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CounterClock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Clock = m_Player.FindAction("Clock", throwIfNotFound: true);
        m_Player_CounterClock = m_Player.FindAction("CounterClock", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Clock;
    private readonly InputAction m_Player_CounterClock;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Clock => m_Wrapper.m_Player_Clock;
        public InputAction @CounterClock => m_Wrapper.m_Player_CounterClock;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Clock.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClock;
                @Clock.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClock;
                @Clock.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClock;
                @CounterClock.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCounterClock;
                @CounterClock.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCounterClock;
                @CounterClock.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCounterClock;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Clock.started += instance.OnClock;
                @Clock.performed += instance.OnClock;
                @Clock.canceled += instance.OnClock;
                @CounterClock.started += instance.OnCounterClock;
                @CounterClock.performed += instance.OnCounterClock;
                @CounterClock.canceled += instance.OnCounterClock;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnClock(InputAction.CallbackContext context);
        void OnCounterClock(InputAction.CallbackContext context);
    }
}
