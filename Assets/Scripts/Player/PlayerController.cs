using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

       public bool isReloading, isJumping, isRunning, isAiming, wasRunningInterupted;
    public bool inInventory;

    public InventoryComponent inventory;
    public GameUIController uIController;

    private void Awake()
    {
        if(inventory == null)
            inventory = GetComponent<InventoryComponent>();
       
        if(uIController == null)
            uIController = FindObjectOfType<GameUIController>();
    }

    public void OnInventory(InputValue input)
    {
        if(inInventory)
        {
            inInventory = false;
        }
        else
        {
            inInventory = true;
        }
        OpenInventory(inInventory);
    }

    private void OpenInventory(bool open)
    {
        if(open)
        {
            uIController.EnableInventoryMenu();
        }
        else
            uIController.EnableGameMenu();
    }
}
