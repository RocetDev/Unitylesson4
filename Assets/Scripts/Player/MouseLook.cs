using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction look;

    public float mouseSensitivity = 0.8f;

    private Transform playerTransform;
    private Transform cameraTransform;
    private float xRotation = 0f;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    public void SetupInputAsset(InputActionAsset inputAsset)
    {
        this.inputAsset = inputAsset;
        InitInput();
    }

    void InitInput()
    {   
        player = inputAsset.FindActionMap("Player");
        look = player.FindAction("Look");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        if (look == null)
        {
           InitInput();
           return;
        }

        Vector2 lookValue = look.ReadValue<Vector2>();
        float mouseX = lookValue.x * mouseSensitivity;
        playerTransform.Rotate(Vector3.up * mouseX);

        float mouseY = lookValue.y * mouseSensitivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
