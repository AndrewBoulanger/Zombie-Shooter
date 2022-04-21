using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable")]
public class ConsumableScript : ItemScript
{
    public int  effect = 0;
    
    public EffectsScript[] Effects;

    public override void UseItem(PlayerController playerController)
    {
        bool DidAnEffectWork = false;

        foreach(EffectsScript e in Effects)
        {
           bool worked = e.ApplyEffect(playerController, effect);
            if(worked) DidAnEffectWork = true;
        }

        //if none of the affects worked (ex. drank health potion at max health) dont delete item
        if(DidAnEffectWork)
        {
            ChangeAmount(-1);
            if (amountValue <= 0)
                DeleteItem(playerController);
        }
    }
}
