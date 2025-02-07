// GENERATED AUTOMATICALLY FROM 'Assets/Control System/Control Scheme.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControlScheme : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlScheme()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control Scheme"",
    ""maps"": [
        {
            ""name"": ""ClickMap"",
            ""id"": ""499cdcea-6fae-4b5e-b2ad-071ff4cbc40a"",
            ""actions"": [
                {
                    ""name"": ""Mouse Click"",
                    ""type"": ""Button"",
                    ""id"": ""c6a6b87a-e9fc-41e3-a4de-6f3509feafd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5131a981-5bcf-4996-b69e-771e293ce3d7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ClickMap
        m_ClickMap = asset.FindActionMap("ClickMap", throwIfNotFound: true);
        m_ClickMap_MouseClick = m_ClickMap.FindAction("Mouse Click", throwIfNotFound: true);
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

    // ClickMap
    private readonly InputActionMap m_ClickMap;
    private IClickMapActions m_ClickMapActionsCallbackInterface;
    private readonly InputAction m_ClickMap_MouseClick;
    public struct ClickMapActions
    {
        private @ControlScheme m_Wrapper;
        public ClickMapActions(@ControlScheme wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_ClickMap_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_ClickMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClickMapActions set) { return set.Get(); }
        public void SetCallbacks(IClickMapActions instance)
        {
            if (m_Wrapper.m_ClickMapActionsCallbackInterface != null)
            {
                @MouseClick.started -= m_Wrapper.m_ClickMapActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_ClickMapActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_ClickMapActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_ClickMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public ClickMapActions @ClickMap => new ClickMapActions(this);
    public interface IClickMapActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
    }
}
