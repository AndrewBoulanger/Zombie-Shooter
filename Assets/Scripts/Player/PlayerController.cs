using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public bool isReloading, isJumping, isRunning, isAiming, wasRunningInterupted, isDead;
    public bool inInventory, gameIsPaused;

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
        if(open && !isDead)
        {
            uIController.EnableInventoryMenu();
        }
        else
            uIController.EnableGameMenu();
    }

    public void OnPause(InputValue input)
    {
        gameIsPaused = !gameIsPaused;

        PauseGame(gameIsPaused);
    }
    private void PauseGame(bool pause)
    {
        if(pause && !isDead)
        { 
            Time.timeScale = 0;
            uIController.EnablePauseMenu();
        }
        else 
        { 
            Time.timeScale = 1;
            uIController.EnableGameMenu();
        }
    }

    private void OnDeath()
    {
        isDead = true;
        GetComponent<Animator>().SetBool("IsDead", true);
    }

    private void OnEnable()
    {
        PlayerEvents.OnPlayerDeath += OnDeath;
    }
    private void OnDisable()
    {
        
            PlayerEvents.OnPlayerDeath -= OnDeath;
    }


}
