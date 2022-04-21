using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory{ None, Weapon, Consumable, Equiptment, ammo}

[System.Serializable]
public abstract class ItemScript : ScriptableObject
{
    public string name = "item";
    public ItemCategory itemCategory = ItemCategory.None;
    public GameObject itemPrefab;
    public bool stackable;
    public int maxSize = 1;


    public delegate void AmountChange();
    public event AmountChange OnAmountChange;

    public delegate void ItemDestroyed();
    public event ItemDestroyed OnItemDestroyed;

    public delegate void ItemDropped();
    public event ItemDropped OnItemDropped;


    public int amountValue = 1;

    public PlayerController controller;
    public virtual void Initialize(PlayerController playerController)
    {
        controller = playerController;
    }

    public virtual bool canWrite
    {
        get
        {
            return false;
        }
    }

    public abstract void UseItem(PlayerController playerController);

    public virtual void DeleteItem(PlayerController playerController)
    {
        OnItemDestroyed?.Invoke();
    }

    public virtual void DropItem(PlayerController playerController)
    {
        OnItemDestroyed?.Invoke();
    }

    public void ChangeAmount(int amount)
    {
        amountValue += amount;
        OnAmountChange?.Invoke();
    }

    public void SetAmount(int amount)
    {
        amountValue = amount;
        OnAmountChange?.Invoke();
    }
}
