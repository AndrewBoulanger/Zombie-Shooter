using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InventoryComponent : SaveableMO
{
    [SerializeField] private List<ItemScript> Items = new List<ItemScript>();
     [SerializeField] private List<ItemScript> StartingItems = new List<ItemScript>();
    [SerializeField] public List<ItemScript> prefabs; 

    string startingBow = "Standard Bow";

    private PlayerController Controller;
    private WeaponHolder weaponHolder;
    
    public override void Awake()
    {
        Controller = GetComponent<PlayerController>();
        weaponHolder = GetComponent<WeaponHolder>();
        base.Awake();
    }

    private void Start()
    {
        if(Items.Count == 0)
        {
            foreach (ItemScript item in StartingItems)
            {
                AddItem(item);
            }
        }
       
        ItemScript bow = FindItem(startingBow);

        if(bow != null)
            bow.UseItem(Controller);
    }

    public List<ItemScript> GetItemList() => Items;

    public int GetItemCount() => Items.Count;

    public ItemScript FindItem(string itemName)
    {
        return Items.Find((invItem) => invItem.name == itemName);
    }

    public void AddItem(ItemScript item, int amount = 0)
    {
        int itemIndex = Items.FindIndex(listItem => listItem.name == item.name);
        if (itemIndex != -1)
        {
            ItemScript listItem = Items[itemIndex];
            if (listItem.stackable && listItem.amountValue < listItem.maxSize)
            {
                listItem.ChangeAmount(item.amountValue);
            }
        }
        else
        {
            if (item == null) return;

            ItemScript itemClone = Instantiate(item);
            itemClone.Initialize(Controller);
            itemClone.SetAmount(amount <= 1 ? item.amountValue : amount);
            Items.Add(itemClone);
        }
    }

    public void DeleteItem(ItemScript item)
    {
        Debug.Log($"{item.name} deleted!");
        int itemIndex = Items.FindIndex(listItem => listItem.name == item.name);
        if (itemIndex == -1) return;

        Items.Remove(item);
    }

    public List<ItemScript> GetItemsOfCategory(ItemCategory itemCategory)
    {
        if (Items == null || Items.Count <= 0) return null;

        return itemCategory == ItemCategory.None ? Items : 
            Items.FindAll(item => item.itemCategory == itemCategory);
    }

    public void UnequipByCategory(ItemCategory category, ItemScript exception)
    {
        List<ItemScript> all = GetItemsOfCategory(category);
        foreach(ItemScript i in all)
        {
            if(i != exception)
                (i as WeaponItemScript).Equipped = false;
        }
    }

    protected override void SaveData()
    {
        List<string> itemIds = new List<string>(Items.Count);
        foreach (ItemScript i in Items)
        {
            itemIds.Add(i.itemPrefab.name);
        }
        PersistantSaveInfo.saveObject(new InventorySave(itemIds, weaponHolder.equippedWeapon.weaponStats.weaponName), "inventory");
    }

    protected override void LoadData()
    {
        InventorySave save =  null;
        PersistantSaveInfo.loadObject<InventorySave>("inventory", ref save);
        if(save != null)
        {
            foreach (string i in save.items)
            {
                StartingItems.Add(prefabs.Find(_ => _.itemPrefab.name == i));
            }
            startingBow = save.startingBow;
        }
    }
}

[System.Serializable]
public class InventorySave
{
    public List<string> items = new List<string>();
    public string startingBow;
    public InventorySave(List<string> _items, string bow)
    {
        items = _items;
        startingBow = bow;
    }
}