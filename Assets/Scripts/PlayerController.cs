using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private float xRotation;
    private float yRotation;

    private float gravity = 9.8f;
    private float verticalVelocity;
    private float speed;

    private Vector3 moveDirection;

    private CharacterController controller;
    private Transform camera;

    [Header("Movement")]
    [Range(0f, 10f), Tooltip("The target walk speed of the player.")]
    public float walkSpeed = 5f;

    [Range(10f, 40f), Tooltip("The target sprint speed of the player.")]
    public float sprintSpeed = 10f;

    [Range(0f, 100f), Tooltip("The speed at which the player goes from walking to sprinting.")]
    public float sprintAcceleration = 5f;

    [Space]

    [Range(0f, 10f), Tooltip("The target height the player will jump.")]
    public float jumpHeight = 2f;

    [Range(0f, 30f), Tooltip("The time the player must wait to jump again.")]
    public float jumpCooldown = 1f;

    [Space]

    [Range(0f, 100f), Tooltip("Controls the player's look sensitivity.")]
    public float lookSensitivity = 10;

    [Header("Key Bindings")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    private bool canJump = true;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        camera = GameObject.Find("Camera").GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        InputManagement();
        Movement();
    }

    private void Movement()
    {
        GroundMovement();
        CameraMovement();
    }

    private void CameraMovement()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * lookSensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void GroundMovement()
    {
        moveDirection = (camera.forward * verticalInput + camera.right * horizontalInput).normalized;

        if(Input.GetKey(sprintKey)){
            speed = Mathf.Lerp(speed, sprintSpeed, sprintAcceleration * Time.deltaTime);
        }
        else{
            speed = Mathf.Lerp(speed, walkSpeed, sprintAcceleration * Time.deltaTime);
        }

        moveDirection.y = Gravity();
        moveDirection *= speed;
        
        controller.Move(moveDirection * Time.deltaTime);
    }
    

    private float Gravity()
    {
        if(controller.isGrounded)
        {
            verticalVelocity = -1f;

            if(Input.GetKey(jumpKey) && canJump){
                //calculates velocity needed to reach desired jump height
                verticalVelocity = Mathf.Sqrt(jumpHeight * gravity * 2);
                canJump = false;

                StartCoroutine(JumpDelay());
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

    private void InputManagement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    IEnumerator JumpDelay(){
        yield return new WaitForSeconds(jumpCooldown);

        canJump = true;
    }
}
