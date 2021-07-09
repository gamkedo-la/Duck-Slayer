using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandPreference : MonoBehaviour
{
    [SerializeField] Transform vrRightHand;
    [SerializeField] Transform vrLeftHand;
    [SerializeField] Transform webRightHand;
    [SerializeField] Transform webLeftHand;

    [SerializeField] Transform gunPrefab;
    RaycastShoot gunshotTrigger;

    [SerializeField] InputActionReference webGLgun;
    [SerializeField] InputActionReference vrRightTrigger;
    [SerializeField] InputActionReference vrLeftTrigger;


    private bool isRightHand = true;
    private SetVROrNot vrstate;

    private void Awake()
    {
        vrstate = GetComponent<SetVROrNot>();
        gunshotTrigger = gunPrefab.GetComponent<RaycastShoot>();
    }

    void Start()
    {
        AttachGunToHand();

    }

    public void SetHandPreference(bool rightHand)
    {
        isRightHand = rightHand;
        AttachGunToHand();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
            ToggleHand();
    }

    [ContextMenu("Toggle Hand")]
    public void ToggleHand()
    {
        isRightHand = !isRightHand;
        AttachGunToHand();
    }

    private void AttachGunToHand()
    {
        if (vrstate.IsPlayerVR())
        {
            gunPrefab.parent = isRightHand ? vrRightHand : vrLeftHand;
            gunPrefab.localPosition = Vector3.zero;
            gunPrefab.localScale = Vector3.one;
            gunPrefab.localEulerAngles = Vector3.zero;

            gunshotTrigger.ResetInputReference(isRightHand ? vrRightTrigger : vrLeftTrigger);

            var reloadTrigger = GetComponent<ReloadButtonXR>();
            reloadTrigger.ResetInputReference(isRightHand ? vrLeftTrigger : vrRightTrigger);

            return;
        }

        //Debug.Log("Toggle Hand " + isRightHand);
        gunPrefab.parent = isRightHand ? webRightHand : webLeftHand;
        gunPrefab.localPosition = Vector3.zero;
        gunPrefab.localScale = Vector3.one;

        gunshotTrigger.ResetInputReference(webGLgun);
    }
}
