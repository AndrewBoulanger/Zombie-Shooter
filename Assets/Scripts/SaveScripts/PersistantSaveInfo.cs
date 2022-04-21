using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistantSaveInfo : MonoBehaviour
{
    public delegate void SaveGameDelegate();
    public static event SaveGameDelegate StartSavingGame;

    static bool LoadOnLevel = false;
    public static bool HasSaveData = false;
    public static bool ShouldLoadLevel 
    {
        get => LoadOnLevel; 
        set 
        { 
            LoadOnLevel = value;
            LoadData();
            if(LoadOnLevel && HasSaveData)
                SceneManager.sceneLoaded += LoadSavedObjects;
            else
                SceneManager.sceneLoaded -= LoadSavedObjects;
        }
    }


    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    static void LoadSavedObjects(Scene scene, LoadSceneMode mode )
    {
        if(scene.name == "GameScene")
        {
            ShouldLoadLevel = false;
        }
    }

    public static void saveObject(object o, string name)
    {
        string text = JsonUtility.ToJson(o);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + name + ".json",  text);
        print("Saved " + name);
    }

    public static void loadObject<T>(string name, ref T result)
    {
       string filePath = Application.persistentDataPath + "/" + name + ".json"; 
        if(System.IO.File.Exists(filePath))
        {
            string jsonString = System.IO.File.ReadAllText(Application.persistentDataPath + "/" + name + ".json");
            result = JsonUtility.FromJson<T>(jsonString);
        }
        
       
    }

    public static void Invoke_StartSavingData()
    {
        StartSavingGame?.Invoke();
        SaveData();
    }

    protected static  void SaveData()
    {
        SaveDataObject save = new SaveDataObject();
        save.doesSaveDataExist = true;
        string saveString = JsonUtility.ToJson(save);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/saveData.json", saveString);
    }

    protected static void LoadData()
    {
        string filePath = Application.persistentDataPath + "/saveData.json";
        if(!System.IO.File.Exists(filePath))  return;
        string jsonString = System.IO.File.ReadAllText(filePath);
        SaveDataObject save = null;
        loadObject<SaveDataObject>(jsonString, ref save);
        
        if(save!= null)
            HasSaveData = save.doesSaveDataExist;
        else 
            HasSaveData = false;
    }

}

[System.Serializable]
public class SaveDataObject
{
    public bool doesSaveDataExist;
}