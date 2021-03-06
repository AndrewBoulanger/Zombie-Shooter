using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthComponent : HealthComponent
{

    protected override void Start()
    {
        base.Start();
        
        PlayerEvents.Invoke_OnHealthInitialized(this);
    }

    public override void Destroy()
    {
        //end level - game over

        PlayerEvents.Invoke_OnPlayerDeath();

    }

    public void SaveData()
    {
        
    }

    public void LoadData()
    {
      
    }
}
