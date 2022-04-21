using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableMO : MonoBehaviour
{
    protected string pathId;

    public virtual void Awake()
    {
        if(PersistantSaveInfo.ShouldLoadLevel)
            LoadData();
    }

    public virtual void OnEnable()
    {
        PersistantSaveInfo.StartSavingGame += SaveData;
    }
    //remember to overload this for disabled objects we need to save
    public virtual void OnDisable()
    {
        PersistantSaveInfo.StartSavingGame -= SaveData;
    }
    protected abstract void SaveData();

    protected abstract void LoadData();
}
