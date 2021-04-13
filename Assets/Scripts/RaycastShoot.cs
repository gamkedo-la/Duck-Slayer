using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast_Shoot : MonoBehaviour
{

    public InputActionReference FireButton;
    // Start is called before the first frame update
    void Start()
    {
      FireButton.action.performed += HandleFireButtonPress;
    }

    void HandleFireButtonPress(InputAction.CallbackContext obj)
    {
      RaycastHit hit;
      if(Physics.Raycast(transform.position, transform.forward, out hit))
      {
        Target target = hit.transform.GetComponent<Target>();
        target.TakeDamage(100.0f);
      }
    }
}
