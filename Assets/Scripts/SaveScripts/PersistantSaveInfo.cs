using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PersistantSaveInfo 
{
    static bool LoadOnLevel = false;

    public static bool ShouldLoadLevel 
    {
        get => LoadOnLevel; 
        set 
        { 
            LoadOnLevel = value;
            if(LoadOnLevel)
                SceneManager.activeSceneChanged += LoadSavedObjects;
            else
                SceneManager.activeSceneChanged -= LoadSavedObjects;
        }
    }


    static void LoadSavedObjects(Scene OldScene, Scene newScene )
    {
        if(newScene.name == "GameScene")
        {
            foreach(GameObject go in newScene.GetRootGameObjects())
            {
                if( go.TryGetComponent<ISaveable>(out ISaveable s))
                    s.LoadData();
                 
            }
            ShouldLoadLevel = false;
        }
    }
}
