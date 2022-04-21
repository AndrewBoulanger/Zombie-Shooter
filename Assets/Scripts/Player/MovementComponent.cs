using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : SaveableMO
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

    LayerMask notPlayer;

    float Momentum;

    [SerializeField]
    float accelerationRate, decelerationRate;

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
    public readonly int interuptedRunningHash = Animator.StringToHash("WasRunningInterupted");
   
    //references
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 LookInput = Vector2.zero;
    Vector2 lastMoveInput = Vector2.zero;


    public override void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

        notPlayer = ~LayerMask.NameToLayer("Player");
        base.Awake();
        
    }


    // Update is called once per frame
    void Update()
    {

        if(playerController.isDead || playerController.gameIsPaused) return;

        //player movement
        if(playerController.isJumping == false) 
        {
           
            if (inputVector.magnitude > 0) 
            { 
                moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
                Momentum += Time.deltaTime * accelerationRate;
                lastMoveInput = inputVector;
            }
            else
                Momentum -= Time.deltaTime * decelerationRate;
            Momentum = Mathf.Clamp(Momentum, 0, 1);

            float currentSpeed = (playerController.isRunning) ? runSpeed : walkSpeed;
            currentSpeed = playerController.isAiming ? aimWalkSpeed : currentSpeed;

            Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime) * Momentum;

            animator.SetFloat(MovementXHash, lastMoveInput.x * Momentum);
            animator.SetFloat(MovementYHash, lastMoveInput.y * Momentum);

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
        
    }

    public void OnRun(InputValue value)
    {
        playerController.isRunning = !playerController.isRunning;
        animator.SetBool(isRunningHash, playerController.isRunning);
   
    }

    public void OnJump(InputValue value)
    {
        if(playerController.isJumping || playerController.gameIsPaused) return;
        playerController.isJumping = value.isPressed;

        rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
        animator.SetBool(isJumpingHash, playerController.isJumping);

        InvokeRepeating("LandingCheck", 1f, 0.2f);
    }


    public void OnLook(InputValue value)
    {
        LookInput = value.Get<Vector2>();

    }

    private void LandingCheck()
    {
       
       
        if(Physics.CheckSphere(transform.position, 0.25f, notPlayer))
        {
            playerController.isJumping = false;
            animator.SetBool(isJumpingHash, playerController.isJumping);

            CancelInvoke("LandingCheck");
        }
            
    }

    public void InteruptRun()
    {
        playerController.isRunning = false;
        playerController.wasRunningInterupted = true;
        animator.SetBool(interuptedRunningHash, true);
        animator.SetBool(isRunningHash, playerController.isRunning);


    }

    public void ResumeRunning()
    {
        playerController.wasRunningInterupted = false;
        playerController.isRunning = true;
        animator.SetBool(interuptedRunningHash, false);
        animator.SetBool(isRunningHash, true);


    }

    public void SetMomentum(float f)
    {
        Momentum = f;
    }

    protected override void SaveData()
    {
        PersistantSaveInfo.saveObject(new playerMovementSave(transform, followTarget.transform), "PlayerMov");
    }

    protected override void LoadData()
    {

        playerMovementSave save = null;
        PersistantSaveInfo.loadObject<playerMovementSave>("PlayerMov", ref save);
        if(save != null)
        { 
            gameObject.transform.SetPositionAndRotation(save.playerloc, save.playerRot);
            followTarget.transform.SetPositionAndRotation(save.camLoc, save.camRot);
        }
    }
}

[System.Serializable]
public class playerMovementSave
{
    public Vector3 playerloc, camLoc;
    public Quaternion playerRot, camRot;
    public playerMovementSave(Transform player, Transform follow)
    {
        playerloc = player.position;
        playerRot = player.rotation;
        camLoc = follow.position;
        camRot = follow.rotation;
    }
}