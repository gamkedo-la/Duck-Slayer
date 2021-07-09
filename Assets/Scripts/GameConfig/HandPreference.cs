using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPreference : MonoBehaviour
{
    [SerializeField] Transform vrRightHand;
    [SerializeField] Transform vrLeftHand;
    [SerializeField] Transform webRightHand;
    [SerializeField] Transform webLeftHand;

    [SerializeField] Transform gunPrefab;

    private bool isRightHand = true;
    private SetVROrNot vrstate;

    private void Awake()
    {
        vrstate = GetComponent<SetVROrNot>();
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
            return;
        }

        Debug.Log("Toggle Hand " + isRightHand);
        gunPrefab.parent = isRightHand ? webRightHand : webLeftHand;
        gunPrefab.localPosition = Vector3.zero;
        gunPrefab.localScale = Vector3.one;
    }
}
