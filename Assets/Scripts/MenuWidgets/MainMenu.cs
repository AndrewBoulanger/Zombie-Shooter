using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MainMenu : MonoBehaviour
{
    [SerializeField] private string MenuName;

    //   protected MenuController menuController;
    void Awake()
    {
        // menuController = FindObjectOfType<MenuController>();
        // menuController?.AddMenu(MenuName, this);
               
    }
}
