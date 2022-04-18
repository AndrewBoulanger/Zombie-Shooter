using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquippableScript : ItemScript
{
    bool isEquipped;
    public bool Equipped{get => isEquipped; set => isEquipped = value;}

    public delegate void EquipedStatusChange();
    public event EquipedStatusChange OnEquippedStatusChange;
    
    public override void UseItem(PlayerController playerController)
    {
        Equipped = !Equipped;
        OnEquippedStatusChange?.Invoke();
    }
}
