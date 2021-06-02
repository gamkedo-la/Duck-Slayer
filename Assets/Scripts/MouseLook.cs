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

    [SerializeField] float maxPitch = -55f;
    [SerializeField] float minPitch = 30f;

    void OnEnable()
    {
        horizontalLook.action.performed += HandleHorizontalLook;
        verticalLook.action.performed += HandleVerticalLook;
    }

    void OnDisable()
    {
        horizontalLook.action.performed -= HandleHorizontalLook;
        verticalLook.action.performed -= HandleVerticalLook;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
    }

    void HandleHorizontalLook(InputAction.CallbackContext obj)
    {
        yaw += obj.ReadValue<float>();
        playerBody.localRotation = Quaternion.AngleAxis(yaw, Vector3.up);

    }

    void HandleVerticalLook(InputAction.CallbackContext obj)
    {
        pitch -= obj.ReadValue<float>();

        transform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(pitch, maxPitch, minPitch),
                                                       Vector3.right);
    }


}
