using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
            playerController.GetComponent<WeaponHolder>().EquipWeapon(this);
        }
        base.UseItem(playerController);
        
    }

}
