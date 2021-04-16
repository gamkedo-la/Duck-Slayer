using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_On_Y : MonoBehaviour
{
    public float rotationSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed, 0f) * Time.deltaTime);
    }
}
