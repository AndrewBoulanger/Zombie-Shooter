using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [Header("Weapon To Spawn"), SerializeField]
    GameObject weaponToSpawn;
    public WeaponComponent equippedWeapon;

    public PlayerController playerController;
    MovementComponent movementComponent;
    Animator animator;

    int ammoCount = 0;

    Sprite crosshairImage;

    [SerializeField]
    Transform weaponSocket;
    [SerializeField]
    Transform gripIKSocketLocation;

    bool waitingToAim;

    public readonly int isAimingHash = Animator.StringToHash("isAiming");
    public readonly int cancelledAimingHash = Animator.StringToHash("cancelledAiming");
    public readonly int isReloadingHash = Animator.StringToHash("isDrawingArrow");

    InputAction AimInput;
    PlayerInputActions actions;

    public delegate void OnArrowFiredDel(int ammo);
    public event OnArrowFiredDel OnArrowFired; 

    public int AmmoCount {get => ammoCount; private set => ammoCount = value;}

    private void Awake()
    {
        actions = new PlayerInputActions();
        AimInput = actions.playerActionMap.Aim;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        GameObject spawnObject = Instantiate(weaponToSpawn, weaponSocket.position, weaponSocket.rotation, weaponSocket);

        equippedWeapon = spawnObject.GetComponent<WeaponComponent>();
        equippedWeapon.Initialize(this);
        gripIKSocketLocation = equippedWeapon.ikGripLocation;

        playerController = GetComponent<PlayerController>();
        movementComponent = GetComponent<MovementComponent>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, gripIKSocketLocation.position);
    }

    private void Update()
    {
        if(playerController.gameIsPaused || playerController.isDead)
            return;
        if(playerController.isAiming && AimInput.phase == InputActionPhase.Waiting)
        {
            LooseArrow();
            StopAiming();
        }
        else if(!playerController.isAiming && AimInput.phase == InputActionPhase.Started)
        {
            StartArrowDrawBack();
        }
    }

    public void OnAim( InputValue value)
    {

            if (value.isPressed && !playerController.gameIsPaused)
            {
                StartArrowDrawBack();
            }

            //released arrow
            else if(playerController.isAiming)
            {
                LooseArrow();

                StopAiming();
            }

    }

    void StopAiming()
    {
        waitingToAim = false;

        playerController.isAiming = false;
        animator.SetBool(isAimingHash, false);

        if (playerController.wasRunningInterupted)
        {
            movementComponent.ResumeRunning();
        }
       
        movementComponent.SetMomentum(0.1f);
    }

    public void OnCancelAiming(InputValue value)
    {
        if (playerController.isAiming)
        {
            animator.SetTrigger(cancelledAimingHash);
            StopAiming();
        }
    }

    private void StartArrowDrawBack()
    {
        if(ammoCount <= 0)
            return;

        if(playerController.isReloading == false)
        {
            equippedWeapon.StartDrawingArrow();

            playerController.isAiming = true;
            animator.SetBool(isAimingHash, playerController.isAiming);

            if (playerController.isRunning)
            {
                movementComponent.InteruptRun();
            }
        }
        else 
        { 
            waitingToAim = true;
            Invoke("StartArrowDrawBack", 0.5f);
        }

    }

    private void LooseArrow()
    {
        playerController.isReloading = true;
        equippedWeapon.Shoot();
        ammoCount -= equippedWeapon.weaponStats.arrowsPerShot;
        OnArrowFired?.Invoke(ammoCount);
        animator.SetBool(isReloadingHash, true);
    }

    public void AddAmmo(int ammoToAdd)
    {
        int oldAmmo = ammoCount;
        ammoCount += ammoToAdd;
        
        if(oldAmmo < 1)
        {
            StartArrowDrawBack();
        }
    }


    public void EquipWeapon(WeaponItemScript newWeapon)
    {
        equippedWeapon.weaponStats = newWeapon.weaponStats;
        equippedWeapon.mesh.materials = newWeapon.itemPrefab.GetComponent<WeaponComponent>().mesh.sharedMaterials;
        GetComponent<InventoryComponent>().UnequipByCategory(ItemCategory.Weapon, newWeapon);
    }

    private void OnEnable()
    {
        actions.Enable();
    }
    private void OnDisable()
    {
        actions.Disable();
    }
}
