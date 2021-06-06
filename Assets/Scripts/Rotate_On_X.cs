using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_On_X : MonoBehaviour
{
    public float rotationSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeed, 0f, 0f) * Time.deltaTime);
    }
}
