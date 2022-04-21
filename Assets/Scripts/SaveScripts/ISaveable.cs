using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISaveable 
{
    void SaveData();

    void LoadData();
}
