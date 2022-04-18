using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weapon", menuName = "Items/Weapon")]
public class WeaponItemScript : EquippableScript
{
    public WeaponStats weaponStats;

    public override void UseItem(PlayerController playerController)
    {
        if(Equipped)
        {

        }
        else
        {

        }
        base.UseItem(playerController);
        
    }

}
