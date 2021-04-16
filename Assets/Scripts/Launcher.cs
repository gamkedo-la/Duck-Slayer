using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float spawnTime = 2f;
    public float thrust = 1.0f;
    private WaitForSeconds timeBetweenLaunches;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenLaunches = new WaitForSeconds(spawnTime);
        StartCoroutine(LaunchProjectile());
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    private IEnumerator LaunchProjectile()
    {
      GameObject box = Instantiate(ItemPrefab, transform);
      Rigidbody boxRB = box.GetComponent<Rigidbody>();
      if(boxRB != null) 
      {
        boxRB.AddForce(transform.up * thrust);
      }
      yield return timeBetweenLaunches;
      StartCoroutine(LaunchProjectile());
    }
}
