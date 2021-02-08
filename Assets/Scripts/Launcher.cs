using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float thrust = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    void LaunchProjectile()
    {
      GameObject box = Instantiate(ItemPrefab, transform);
      Rigidbody boxRB = box.GetComponent<Rigidbody>();
      if(boxRB != null) 
      {
        boxRB.AddForce(transform.up * thrust);
      }
    }
}
