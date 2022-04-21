using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class EquippableScript : ItemScript
{
    bool isEquipped;
    public bool Equipped
    {
        get => isEquipped; 
        set
        { 
            isEquipped = value;
            OnEquippedStatusChange?.Invoke();
        }
    }

    public delegate void EquipedStatusChange();
    public event EquipedStatusChange OnEquippedStatusChange;
    
    public override void UseItem(PlayerController playerController)
    {
        if(!Equipped)
        { 
            Equipped = true;
            OnEquippedStatusChange?.Invoke();
        }
    }
}
