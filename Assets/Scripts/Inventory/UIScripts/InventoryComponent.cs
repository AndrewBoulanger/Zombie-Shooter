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

    ItemScript arrows;
    
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
        arrows = FindItem("Arrows");
        weaponHolder.AddAmmo(arrows.amountValue);
        
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

    void OnArrowUsed(int numArrows)
    {
        arrows.amountValue = numArrows;
    }

    public override void OnEnable()
    {
        weaponHolder.OnArrowFired += OnArrowUsed;
        base.OnEnable();
    }
    public override void OnDisable()
    {
        weaponHolder.OnArrowFired -= OnArrowUsed;
        base.OnDisable();
    }


    protected override void SaveData()
    {
        List<string> itemIds = new List<string>(Items.Count);
        List<int> amounts = new List<int>(Items.Count);
        foreach (ItemScript i in Items)
        {
            itemIds.Add(i.itemPrefab.name);
            amounts.Add(i.amountValue);
        }
        PersistantSaveInfo.saveObject(new InventorySave(itemIds, amounts, weaponHolder.equippedWeapon.weaponStats.weaponName), "inventory");
    }

    protected override void LoadData()
    {
        InventorySave save =  null;
        PersistantSaveInfo.loadObject<InventorySave>("inventory", ref save);
        if(save != null)
        {
            for(int i= 0; i < save.items.Count; i++)
            {
                StartingItems.Add(prefabs.Find(_ => _.itemPrefab.name == save.items[i]));
                StartingItems[i].amountValue = save.amounts[i];
            }
            startingBow = save.startingBow;
        }
    }
}

[System.Serializable]
public class InventorySave
{
    public List<string> items = new List<string>();
    public List<int> amounts = new List<int>();
    public string startingBow;
    public InventorySave(List<string> _items, List<int> _amounts, string bow)
    {
        items = _items;
        amounts = _amounts;
        startingBow = bow;
    }
}