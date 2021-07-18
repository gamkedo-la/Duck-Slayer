using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastShoot : MonoBehaviour
{
    public InputActionReference FireButton;
    public ParticleSystem particlesOnShoot;
    public GameObject gun;
    public Transform endOfGun;
    public GameEvent dryFireEvent;
    public float gunDamage = 100f;
    [SerializeField] float gunShotRadius = 0.1f;

    private BulletManager bulletManager;
    [Header("Debug")]
    [SerializeField] private bool logDebug = false;

    private void Awake()
    {
        Debug.Log($"Debug Log value is [{logDebug}] in [{this.gameObject.name}:{this.GetType().Name}]]");
    }

    private void Start()
    {
        bulletManager = GetComponent<BulletManager>();
        if (bulletManager == null)
        {
            if(logDebug) Debug.Log("no bullet manager found", gameObject);
        }
    }

    private void HandleFireButtonPress(InputAction.CallbackContext obj)
    {
        int bulletCount = bulletManager.GetBulletAmount();
        if (bulletCount <= 0)
        {
            if(logDebug) Debug.Log("Out of Ammo");
            dryFireEvent?.Invoke();

            return;
        }

        bulletManager.DecreaseBullets();

        FireGun();
    } // end HandleFireButtonPress

    private void FireGun()
    {
        ParticleSystem muzzleBlast;
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, gunShotRadius, transform.forward, out hit))
        {
            BaseTarget target = hit.transform.GetComponent<BaseTarget>();
            if (target != null)
            {
                target.TakeDamage(gunDamage);
            }
        }

        muzzleBlast = Instantiate(particlesOnShoot, endOfGun.position, endOfGun.rotation);
        Destroy(muzzleBlast, 2f);
    }

    private void OnDestroy()
    {
        FireButton.action.performed -= HandleFireButtonPress;
    }

    public void ResetInputReference(InputActionReference newInputAction)
    {
        FireButton.action.performed -= HandleFireButtonPress;

        FireButton = newInputAction;

        FireButton.action.performed += HandleFireButtonPress;
    }

} // end class