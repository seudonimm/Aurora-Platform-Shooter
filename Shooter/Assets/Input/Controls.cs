// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""MovementAbility"",
            ""id"": ""b71a40e5-f56e-42c6-84fa-e2010da0162f"",
            ""actions"": [
                {
                    ""name"": ""MovementAbility"",
                    ""type"": ""Button"",
                    ""id"": ""6c234ef6-62a1-4e9f-8351-38ac1f15eb8d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d6e99249-3516-492c-9aed-90b3e1d0071b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MovementAbility
        m_MovementAbility = asset.FindActionMap("MovementAbility", throwIfNotFound: true);
        m_MovementAbility_MovementAbility = m_MovementAbility.FindAction("MovementAbility", throwIfNotFound: true);
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

    // MovementAbility
    private readonly InputActionMap m_MovementAbility;
    private IMovementAbilityActions m_MovementAbilityActionsCallbackInterface;
    private readonly InputAction m_MovementAbility_MovementAbility;
    public struct MovementAbilityActions
    {
        private Controls m_Wrapper;
        public MovementAbilityActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementAbility => m_Wrapper.m_MovementAbility_MovementAbility;
        public InputActionMap Get() { return m_Wrapper.m_MovementAbility; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementAbilityActions set) { return set.Get(); }
        public void SetCallbacks(IMovementAbilityActions instance)
        {
            if (m_Wrapper.m_MovementAbilityActionsCallbackInterface != null)
            {
                MovementAbility.started -= m_Wrapper.m_MovementAbilityActionsCallbackInterface.OnMovementAbility;
                MovementAbility.performed -= m_Wrapper.m_MovementAbilityActionsCallbackInterface.OnMovementAbility;
                MovementAbility.canceled -= m_Wrapper.m_MovementAbilityActionsCallbackInterface.OnMovementAbility;
            }
            m_Wrapper.m_MovementAbilityActionsCallbackInterface = instance;
            if (instance != null)
            {
                MovementAbility.started += instance.OnMovementAbility;
                MovementAbility.performed += instance.OnMovementAbility;
                MovementAbility.canceled += instance.OnMovementAbility;
            }
        }
    }
    public MovementAbilityActions @MovementAbility => new MovementAbilityActions(this);
    public interface IMovementAbilityActions
    {
        void OnMovementAbility(InputAction.CallbackContext context);
    }
}
