using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [Header("Weapon To Spawn"), SerializeField]
    GameObject weaponToSpawn;
    WeaponComponent equippedWeapon;

    public PlayerController playerController;
    MovementComponent movementComponent;
    Animator animator;

    Sprite crosshairImage;

    [SerializeField]
    Transform weaponSocket;
    [SerializeField]
    Transform gripIKSocketLocation;

    public readonly int isAimingHash = Animator.StringToHash("isAiming");
    public readonly int cancelledAimingHash = Animator.StringToHash("cancelledAiming");

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

    public void OnAim(InputValue value)
    {
        playerController.isAiming = value.isPressed;

        if (value.isPressed)
        {
            StartArrowDrawBack();
        }

        //released arrow
        else if (value.isPressed == false)
        {
            LooseArrow();

            if (playerController.wasRunningInterupted)
            {
                movementComponent.ResumeRunning();
            }
        }

        animator.SetBool(isAimingHash, playerController.isAiming);

    }

    public void OnCancelAiming(InputValue value)
    {
        if (playerController.isAiming)
        {
            playerController.isAiming = false;
            animator.SetTrigger(cancelledAimingHash);
            animator.SetBool(isAimingHash, false);
        }
    }

    private void StartArrowDrawBack()
    {
        if(playerController.isReloading == false)
        {
            equippedWeapon.StartDrawingArrow();
            if (playerController.isRunning)
            {
                movementComponent.InteruptRun();
            }
        }
    }

    private void LooseArrow()
    {
        playerController.isReloading = true;
        equippedWeapon.Shoot();
    }

}
