using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : SaveableMO
{

    public bool isReloading, isJumping, isRunning, isAiming, wasRunningInterupted, isDead;
    public bool inInventory, gameIsPaused;

    public InventoryComponent inventory;
    public GameUIController uIController;

    public override void Awake()
    {
        if(inventory == null)
            inventory = GetComponent<InventoryComponent>();
       
        if(uIController == null)
            uIController = FindObjectOfType<GameUIController>();

        base.Awake();
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

    public override void OnEnable()
    {
        base.OnEnable();
        PlayerEvents.OnPlayerDeath += OnDeath;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PlayerEvents.OnPlayerDeath -= OnDeath;
    }

    protected override void SaveData()
    {
        PersistantSaveInfo.saveObject(new PlayerControllerSave(this), "playerController");
    }

    protected override void LoadData()
    {
        PlayerControllerSave save = null;
        PersistantSaveInfo.loadObject<PlayerControllerSave>("playerController", ref save);
        if(save != null)
        {
            GetComponent<HealthComponent>().CurrentHealth = save.health;
            isJumping = save.controller.isJumping;
            isRunning = save.controller.isRunning;
        }
    }
}

[System.Serializable]
public class PlayerControllerSave
{
    public PlayerController controller;

    public float health;
    public PlayerControllerSave(PlayerController _controller)
    {
        controller = _controller;
        health = controller.GetComponent<HealthComponent>().CurrentHealth;
    }
}