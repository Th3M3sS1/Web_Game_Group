using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : LivingEntity
{
    [Header("Controls")]
    public Joystick joystick;
    public float horizontalSensitivity;
    public float verticalSensitivity;

    public CharacterController controller;

    public float maxSpeed = 10.0f;
    public float gravity = -10.0f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    private Vector3 velocity;
    public bool isGrounded;

    public float mouseSensitivity = 10.0f;
    public Camera cam;

    public float distanceToPlayer;

    //private float XRotation = 0.0f;

    [Header("MiniMap")]
    public GameObject miniMap;

    [Header("Inventory")]
    public GameObject Inventory;

    [Header("Gun")]
    public GunScript gun;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;        

        healthBar.fillAmount = currentHealth / maxHealth;
    }

    // Update is called once per frame - once every 16.6666ms

    void Update()
    {
        if (GameManager.instance.currentState == GameManager.GameState.GameRun)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2.0f;
            }

            //Input for WebGL and Desktop
            //float x = Input.GetAxis("Horizontal");
            //float z = Input.GetAxis("Vertical");

            /*if(Input.GetMouseButtonDown(0))
            {
                gun.Fire();
            }*/

            //Input for Mobile
            float x = joystick.Horizontal;
            float z = joystick.Vertical;


            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);



            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * maxSpeed * Time.deltaTime);

            if (Input.GetButton("Jump") && isGrounded)
            {
                Jump();
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            /* //Moved this script to cam controller
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            XRotation -= mouseY;
            XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);

            cam.transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
            transform.Rotate(Vector3.up * mouseX);
            */

            if (Input.GetKeyUp(KeyCode.M))
                TakeDamage(20.0f);
        }
    }

    //mobile control code to jump
    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }

    //mobile control code to toggle minimap
    public void ToggleMiniMap()
    {
        //toggle the MiniMap on/off\
        miniMap.SetActive(!miniMap.activeInHierarchy);
    }

    //mobile control code to toggle Inventory
    public void ToggleInventory()
    {
        //toggle the Inventory on/off\
        Inventory.SetActive(!Inventory.activeInHierarchy);
    }


    //Take Damge of player implemented in ZombieBehaviour
    /*
    void OnTriggerEnter(Collider other)
    {
        distanceToPlayer = Vector3.Distance(transform.position, other.transform.position);
        if (other.gameObject.CompareTag("Enemy") && distanceToPlayer < 3.2f)
        {
            TakeDamage(20.0f);
            SoundManager.PlaySound("hurt");
            //distanceToPlayer = 10f;
            Debug.Log("Hurt");
        }
    }
    */

    public override void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
