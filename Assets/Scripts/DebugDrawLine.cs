using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawLine : MonoBehaviour
{
    private float LineLength = 200f;

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.position + (transform.forward * LineLength);

        Debug.DrawLine(transform.position, forward, Color.green);
    }
}
