using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    public InputActionReference FireButton;
    public bool isHeld;
    Vector3 lastPosition;
    Button lastHighlightedButton;

    void OnEnable()
    {
        FireButton.action.performed += HandleFireButtonPress;
        FireButton.action.canceled += CancelPress;
    }

    private void CancelPress(InputAction.CallbackContext obj)
    {
        isHeld = false;
    }

    void OnDisable()
    {
        FireButton.action.performed -= HandleFireButtonPress;
    }

    void HandleFireButtonPress(InputAction.CallbackContext obj)
    {
        UIFire();
        isHeld = true;
    }

    private void Update()
    {
        //HandleDrag();

        Hover();
    }

    private void HandleDrag()
    {
        if (isHeld)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 300))
            {
                IBeginDragHandler dragHandler = hit.collider.GetComponent<IBeginDragHandler>();
                if (dragHandler != null)
                {
                    if (transform.rotation.x > lastPosition.y)
                        hit.collider.GetComponent<Scrollbar>().value += (transform.position.y - lastPosition.y);
                    else if (transform.rotation.x < lastPosition.y)
                        hit.collider.GetComponent<Scrollbar>().value -= (lastPosition.y - transform.position.y);

                    lastPosition = hit.point;
                }
            }
        }
    }

    private void Hover()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 300))
        {
            var gameObj = hit.collider.gameObject;
            var button = gameObj.GetComponent<Button>();

            if (button != null)
            {
                button.OnPointerEnter(new PointerEventData(EventSystem.current));

                lastHighlightedButton = button;
                return;
            }
        }

        if (lastHighlightedButton != null)
        {
            lastHighlightedButton.OnPointerExit(null);
            lastHighlightedButton = null;
        }
    }

    private void UIFire()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 300))
        {
            var gameObj = hit.collider.gameObject;
            IPointerClickHandler clickHandler = gameObj.GetComponent<IPointerClickHandler>();

            if (clickHandler != null)
            {
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                Debug.Log("hit " + hit.collider.gameObject.name);
                clickHandler.OnPointerClick(pointerEventData);
                return;
            }
        }

        Debug.Log("Hit Not UI");
    }
}
