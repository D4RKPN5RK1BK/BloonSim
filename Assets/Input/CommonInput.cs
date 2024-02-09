//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/CommonInput.inputactions
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

public partial class @CommonInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CommonInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CommonInput"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""2b9b5904-c98c-444b-83ec-e159cd3590dc"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""a06ddbb3-0e23-491f-8b3c-6c941def576e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d585c963-c8da-4727-a8bd-d44313f8d2c0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InPause"",
            ""id"": ""c6897af3-54aa-4538-a873-45ba6dd05963"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""5895497c-c22a-409b-9af0-22bad6a58150"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a75206a5-34ec-4ecf-8502-e36a2eaa29cb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_Pause = m_InGame.FindAction("Pause", throwIfNotFound: true);
        // InPause
        m_InPause = asset.FindActionMap("InPause", throwIfNotFound: true);
        m_InPause_Pause = m_InPause.FindAction("Pause", throwIfNotFound: true);
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

    // InGame
    private readonly InputActionMap m_InGame;
    private List<IInGameActions> m_InGameActionsCallbackInterfaces = new List<IInGameActions>();
    private readonly InputAction m_InGame_Pause;
    public struct InGameActions
    {
        private @CommonInput m_Wrapper;
        public InGameActions(@CommonInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_InGame_Pause;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void AddCallbacks(IInGameActions instance)
        {
            if (instance == null || m_Wrapper.m_InGameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InGameActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IInGameActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInGameActions instance)
        {
            foreach (var item in m_Wrapper.m_InGameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InGameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InGameActions @InGame => new InGameActions(this);

    // InPause
    private readonly InputActionMap m_InPause;
    private List<IInPauseActions> m_InPauseActionsCallbackInterfaces = new List<IInPauseActions>();
    private readonly InputAction m_InPause_Pause;
    public struct InPauseActions
    {
        private @CommonInput m_Wrapper;
        public InPauseActions(@CommonInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_InPause_Pause;
        public InputActionMap Get() { return m_Wrapper.m_InPause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InPauseActions set) { return set.Get(); }
        public void AddCallbacks(IInPauseActions instance)
        {
            if (instance == null || m_Wrapper.m_InPauseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InPauseActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IInPauseActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IInPauseActions instance)
        {
            if (m_Wrapper.m_InPauseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInPauseActions instance)
        {
            foreach (var item in m_Wrapper.m_InPauseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InPauseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InPauseActions @InPause => new InPauseActions(this);
    public interface IInGameActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IInPauseActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}