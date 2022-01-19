using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{

    [SerializeField]
    float walkSpeed = 5;
    [SerializeField]
    float runSpeed = 10;
    [SerializeField]
    float jumpForce = 5;


    //components
    private PlayerController playerController;
    private Rigidbody rigidbody;
   
    //references
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isJumping) return;
        if(!(inputVector.magnitude > 0)) moveDirection = Vector3.zero;

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

        float currentSpeed = (playerController.isRunning) ? runSpeed : walkSpeed;

        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);

        transform.position += movementDirection;

    }

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    public void OnRun(InputValue value)
    {
        playerController.isRunning = value.isPressed;
    }

    public void OnJump(InputValue value)
    {
        if(playerController.isJumping) return;
        playerController.isJumping = value.isPressed;

        rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && playerController.isJumping)
            playerController.isJumping = false;
    }
}