using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIInteraction : MonoBehaviour
{
    public InputActionReference FireButton;

    void OnEnable()
    {
        FireButton.action.performed += HandleFireButtonPress;
    }

    void OnDisable()
    {
        FireButton.action.performed -= HandleFireButtonPress;
    }

    void HandleFireButtonPress(InputAction.CallbackContext obj)
    {        
        UIFire();
    }

    private void UIFire()
    {
        Debug.Log("Fire");
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 300))
        {
            IPointerClickHandler clickHandler = hit.collider.gameObject.GetComponent<IPointerClickHandler>();

            if (clickHandler != null)
            {
                Debug.Log("hit " + hit.collider.gameObject.name);
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                clickHandler.OnPointerClick(pointerEventData);
            }
            else
            {
                Debug.Log("hit not UI");
            }
        }
    }
}
