using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    private Vector3 velocity;
    public bool isGrounded;

    public float mouseSensitivity = 10.0f;
    public Camera cam;

    private float XRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame - once every 16.6666ms

    void Update()
    {
        if (GameManager.instance.currentState != GameManager.GameState.GamePause)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2.0f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * maxSpeed * Time.deltaTime);

            if (Input.GetButton("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            XRotation -= mouseY;
            XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);

            cam.transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
