using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ammo", menuName = "Items/ammo")]
public class AmmoScript : ItemScript
{
    public override void UseItem(PlayerController playerController)
    {
        ChangeAmount(-1);
        //dont delete, want to show that there are no arrows
    }
}
