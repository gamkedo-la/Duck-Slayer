using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastViewer : MonoBehaviour
{
    public float weaponRange = 50.0f;
    void Update()
    {
      Debug.DrawRay(transform.position, transform.forward * weaponRange, Color.green);
    }
}
