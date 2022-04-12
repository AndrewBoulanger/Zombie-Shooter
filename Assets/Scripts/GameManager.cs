using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    private GameManager()
    {}
    private static GameManager instance;

    public static GameManager GetInstance()
    {
        if(instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }

    ///////////////////////////////////////////////////////
    ///

   


}
