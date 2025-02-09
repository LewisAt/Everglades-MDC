
using System.Collections;
using UnityEngine;

public class PCFirstPersonControllerPlayer : MonoBehaviour
{
    public Camera playerCamera;
    public float fov = 60f;
    public float zoomFOV = 30f;
    public float zoomSpeed = 5f;
    public float walkSpeed = 5f;
    public float sprintSpeed = 7f;
    public float jumpPower = 5f;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 85f;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode jumpKey = KeyCode.Space;

    private bool isZoomed = false;
    private bool isGrounded = true;
    private Rigidbody rb;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera.fieldOfView = fov;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleZoom();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        rb.velocity = new Vector3(moveDirection.x * walkSpeed, rb.velocity.y, moveDirection.z * walkSpeed);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void HandleZoom()
    {
        if (Input.GetMouseButtonDown(1)) isZoomed = !isZoomed;
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, isZoomed ? zoomFOV : fov, zoomSpeed * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);
        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}