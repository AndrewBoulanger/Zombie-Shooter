using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MainMenu : MonoBehaviour
{
    public void OnLoadClicked()
    {
        if(PersistantSaveInfo.HasSaveData)
        { 
            PersistantSaveInfo.ShouldLoadLevel = true;
           SceneManager.LoadScene("GameScene");
        }
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}
