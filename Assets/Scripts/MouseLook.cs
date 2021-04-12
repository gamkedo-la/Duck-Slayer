using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public InputActionReference horizontalLook;
    public InputActionReference verticalLook; 
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    float pitch = 0f;
    float yaw = 0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
      horizontalLook.action.performed += HandleHorizontalLook;
      verticalLook.action.performed += HandleVerticalLook;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void HandleHorizontalLook(InputAction.CallbackContext obj)
    {
      Debug.Log("YE YAAAAW");
      yaw += obj.ReadValue<float>();
      playerBody.localRotation = Quaternion.AngleAxis(yaw, Vector3.up);

    }

    void HandleVerticalLook(InputAction.CallbackContext obj)
    {
      Debug.Log("Lifes a pitch");
      pitch -= obj.ReadValue<float>();
      transform.localRotation = Quaternion.AngleAxis(pitch, Vector3.right);
    }

    
}
