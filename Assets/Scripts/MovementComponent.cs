using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{

    [SerializeField]
    float walkSpeed = 4;
    [SerializeField]
    float runSpeed = 10;
    [SerializeField]
    float aimWalkSpeed = 1;
    [SerializeField]
    float jumpForce = 5;
    [SerializeField]
    float aimSensitivity = 1;


    //components
    private PlayerController playerController;
    private Rigidbody rigidbody;
    private Animator animator;
    public GameObject followTarget;

    //animator hash values
    public readonly int MovementXHash = Animator.StringToHash("MovementX");
    public readonly int MovementYHash = Animator.StringToHash("MovementY");
    public readonly int isRunningHash = Animator.StringToHash("IsRunning");
    public readonly int isJumpingHash = Animator.StringToHash("IsJumping");
    public readonly int isAimingHash = Animator.StringToHash("isAiming");
    public readonly int cancelledAimingHash = Animator.StringToHash("cancelledAiming");
    public readonly int interuptedRunningHash = Animator.StringToHash("WasRunningInterupted");
   
    //references
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 LookInput = Vector2.zero;
    bool interuptedRunning;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        if(playerController.isJumping == false) 
        {
            if (!(inputVector.magnitude > 0)) moveDirection = Vector3.zero;

            moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

            float currentSpeed = (playerController.isRunning) ? runSpeed : walkSpeed;
            currentSpeed = playerController.isAiming ? aimWalkSpeed : currentSpeed;

            Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);

            transform.position += movementDirection;
        }

        //camera movement
        followTarget.transform.rotation *= Quaternion.AngleAxis(LookInput.x * aimSensitivity, Vector3.up);

        followTarget.transform.rotation *= Quaternion.AngleAxis(LookInput.y * aimSensitivity, Vector3.left);

        var angles = followTarget.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTarget.transform.localEulerAngles.x;
        if(angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if(angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        followTarget.transform.localEulerAngles = angles;

        //rotate character based on camera
        transform.rotation = Quaternion.Euler(0, followTarget.transform.rotation.eulerAngles.y, 0);
        followTarget.transform.localEulerAngles = new Vector3(angles.x, 0,0);
    }

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        animator.SetFloat(MovementXHash, inputVector.x);
        animator.SetFloat(MovementYHash, inputVector.y);
    }

    public void OnRun(InputValue value)
    {
        playerController.isRunning = !playerController.isRunning;
        animator.SetBool(isRunningHash, playerController.isRunning);
        print("Running: " + playerController.isRunning);
    }

    public void OnJump(InputValue value)
    {
        print("jump button pressed");

        if(playerController.isJumping) return;
        playerController.isJumping = value.isPressed;

        rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
        animator.SetBool(isJumpingHash, playerController.isJumping);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && playerController.isJumping)
        { 
            playerController.isJumping = false;
            animator.SetBool(isJumpingHash, playerController.isJumping);

            print("landed");
        }
    }

    public void OnAim(InputValue value)
    {
        playerController.isAiming = value.isPressed;
        
        if(value.isPressed)
        {
            if (playerController.isRunning)
            {
                playerController.isRunning = false;
                interuptedRunning = true;
                animator.SetBool(interuptedRunningHash, true);
                animator.SetBool(isRunningHash,playerController.isRunning);
            }
        }

        animator.SetBool(isAimingHash, playerController.isAiming);

        if (value.isPressed == false && interuptedRunning)
        {
            interuptedRunning = false;
            playerController.isRunning = true;
            animator.SetBool(interuptedRunningHash, false);
             animator.SetBool(isRunningHash, true);
        }
    }

    public void OnLook(InputValue value)
    {
        LookInput = value.Get<Vector2>();

    }

    public void OnCancelAiming(InputValue value)
    {
        if(playerController.isAiming)
        { 
            playerController.isAiming = false;
            animator.SetTrigger(cancelledAimingHash);
            animator.SetBool(isAimingHash, false);
        }
    }
}
