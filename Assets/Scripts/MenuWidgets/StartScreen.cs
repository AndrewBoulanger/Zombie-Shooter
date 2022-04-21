using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    InputAction AnyKey;
    PlayerInputActions actions;
    
    private void Awake()
    {
       
       actions = new PlayerInputActions();
       AnyKey = actions.playerActionMap.AnyKey;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void OnEnable()
    {
        
        AnyKey.Enable();
        AnyKey.performed += _ => ChangeScene();
        
    }

    private void OnDisable()
    {
        AnyKey.Disable();
        AnyKey.performed -= _ => ChangeScene();
    }
}
