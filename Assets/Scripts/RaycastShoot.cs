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

    private BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GetComponent<BulletManager>();
        if(bulletManager == null)
        {
          Debug.Log("no bullet manager found", gameObject);
        }
        FireButton.action.performed += HandleFireButtonPress;
    }

    void HandleFireButtonPress(InputAction.CallbackContext obj)
    {
        int bulletCount = bulletManager.GetBulletAmount();
        if (bulletCount <= 0)
        {
            //StartCoroutine(bulletManager.ReloadCoroutine()); // RELOAD

            //Debug.Log("Out of Ammo");
            dryFireEvent?.Invoke();

            return;
        }

        Debug.Log("DecreaseBullets called", gameObject);
        bulletManager.DecreaseBullets();
        Debug.Log(bulletCount);

        FireGun();
    } // end HandleFireButtonPress

    private void FireGun()
    {
        ParticleSystem muzzleBlast;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Target target = hit.transform.GetComponent<Target>();
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
} // end class