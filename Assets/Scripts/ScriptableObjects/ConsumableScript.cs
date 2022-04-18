using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable")]
public class ConsumableScript : ItemScript
{
    public int  effect = 0;
    
    public override void UseItem(PlayerController playerController)
    {
        
        ChangeAmount(-1);

        if(amountValue <= 0)
            DeleteItem(playerController);

        HealthComponent health = playerController.GetComponent<HealthComponent>();

        if(health?.CurrentHealth < health?.MaxHealth)
        {
               health.Heal(effect);
        }
    }
}
