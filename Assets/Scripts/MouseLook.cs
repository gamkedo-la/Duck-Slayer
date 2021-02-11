using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    float pitch = 0f;
    float yaw = 0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

      pitch -= mouseY;
      pitch = Mathf.Clamp(pitch, -70f, 70f);

      yaw += mouseX;
      yaw = Mathf.Clamp(yaw, -45f, 45f);


      //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
      transform.localRotation = Quaternion.AngleAxis(pitch, Vector3.right);
      //playerBody.Rotate(new Vector3(0, 1, 0) * mouseX);
      playerBody.localRotation = Quaternion.AngleAxis(yaw, Vector3.up);

      Debug.Log(playerBody.rotation);
    }

    
}
