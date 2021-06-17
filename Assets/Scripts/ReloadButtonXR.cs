using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Events;

public class ReloadButtonXR : MonoBehaviour
{
    public InputActionReference ReloadButton;
    [SerializeField] GameEvent gameEvent;

    void OnEnable()
    {
        ReloadButton.action.performed += HandleReloadButtonPress;
    }

    void OnDisable()
    {
        ReloadButton.action.performed -= HandleReloadButtonPress;
    }

    void HandleReloadButtonPress(InputAction.CallbackContext obj)
    {
        gameEvent?.Invoke();
    }
}
