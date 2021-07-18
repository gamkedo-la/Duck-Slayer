﻿using System;
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

    [Header("Debug")]
    [SerializeField] private bool logDebug = false;

    private void Awake()
    {
        Debug.Log($"Debug Log value is [{logDebug}] in [{this.gameObject.name}:{this.GetType().Name}]]");
    }

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

            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);

            if (button != null)
            {

                button.OnPointerEnter(pointerEventData);

                if (lastHighlightedButton == null)
                {
                    var eventTrigger = gameObj.GetComponent<EventTrigger>();

                    if (eventTrigger == null)
                        Debug.LogError("No Event Trigger on this button: " + hit.collider.name);
                    else
                        eventTrigger.OnPointerEnter(pointerEventData);
                }

                if (lastHighlightedButton != button)
                    HandlePointerExit();

                lastHighlightedButton = button;
                return;
            }

        }

        HandlePointerExit();
    }

    private void HandlePointerExit()
    {
        if (lastHighlightedButton != null)
        {
            if(logDebug) Debug.Log(lastHighlightedButton.name);

            var eventTrigger = lastHighlightedButton.GetComponent<EventTrigger>();

            if (eventTrigger == null)
            {
                Debug.LogError("No Event Trigger on this button: " + lastHighlightedButton.name);
            }
            else
            {
                eventTrigger.OnPointerExit(new PointerEventData(EventSystem.current));
                lastHighlightedButton.OnPointerExit(null);
            }

            lastHighlightedButton = null;
            if(logDebug) Debug.Log("Exit");
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
                if(logDebug) Debug.Log("hit " + hit.collider.gameObject.name);
                clickHandler.OnPointerClick(pointerEventData);
                return;
            }
        }

        if(logDebug) Debug.Log("Hit Not UI");
    }
}
