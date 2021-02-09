using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour
{
    public Transform gunEnd;
    public float damage = 100f;
    public float range = 1000f;
    public float fireRate = 0.25f;

    private LineRenderer laserLine;
    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.1f);
    private float nextFireTime;

    void Start()
    {
      laserLine = GetComponent<LineRenderer>();
      fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonDown("Fire1")) {
        Shoot();
      }
    }

    void Shoot() 
    {
      RaycastHit hit;
      Vector3 endOfLaser;
      Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
      StartCoroutine(ShotEffect());
      laserLine.SetPosition(0, gunEnd.position);

      if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
      {
        //handle damage if hit
        Target target = hit.transform.GetComponent<Target>();
        if(target != null) {
          target.TakeDamage(damage);
        }

        //handle laser render on hit
        endOfLaser = hit.point;
      } else
      {
        //handle laser render on no hit
        endOfLaser = rayOrigin + (fpsCam.transform.forward * range);
      }

      laserLine.SetPosition(1, endOfLaser);
    }

    private IEnumerator ShotEffect()
    {
      laserLine.enabled = true;
      yield return shotDuration;
      laserLine.enabled = false;

    }
}
