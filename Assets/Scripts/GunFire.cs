using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Transform fpsCam;

    float damage = 100f;
    float range = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
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
      if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
      {
        
        Target target = hit.transform.GetComponent<Target>();
        if(target != null) {
          target.TakeDamage(damage);
        }
      }
    }
}
