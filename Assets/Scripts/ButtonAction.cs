using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Events;

public class ButtonAction : MonoBehaviour
{
    public InputActionReference[] InputButtons;
    [SerializeField] GameEvent gameEvent;

    void OnEnable()
    {
      foreach(InputActionReference inputAction in InputButtons)
      {
        inputAction.action.performed += HandleButtonPress;
      }
    }

    void OnDisable()
    {
      foreach(InputActionReference inputAction in InputButtons)
      {
        inputAction.action.performed -= HandleButtonPress;
      }
    }

    public virtual void HandleButtonPress(InputAction.CallbackContext obj)
    {
        gameEvent?.Invoke();
    }
}
