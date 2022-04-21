using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupComponent : SaveableMO
{
    [SerializeField]
    ItemScript pickupItem;

    [SerializeField]
    int amount = -1;

    [SerializeField] MeshRenderer PropMeshRenderer;
    [SerializeField] MeshFilter propMeshFilter;

    ItemScript itemInstance;

    static int itemId;

    public override void Awake()
    {
        pathId = "pickupNum" + itemId++;
        base.Awake();
        if(gameObject.activeSelf)
            InstantiateItem();
    }

    private void InstantiateItem()
    {
        itemInstance = Instantiate(pickupItem);
        amount = amount > 0 ? amount : pickupItem.amountValue;
        itemInstance.SetAmount(amount);
        ApplyMesh();
    }

    private void ApplyMesh()
    {
        if(propMeshFilter) propMeshFilter.mesh = pickupItem.itemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
        if(PropMeshRenderer) PropMeshRenderer.materials = pickupItem.itemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;

        InventoryComponent playerInv = other.GetComponent<InventoryComponent>();
        playerInv.AddItem(pickupItem, itemInstance.amountValue);

        if(itemInstance.itemCategory == ItemCategory.ammo)
        {
            other.GetComponent<WeaponHolder>().AddAmmo(amount);
        }

        gameObject.SetActive(false);
    }

    public override void OnDisable()
    { }

    protected override void SaveData()
    {
       PersistantSaveInfo.saveObject(new PickupSave(!gameObject.activeSelf), pathId);
    }

    protected override void LoadData()
    {
       PickupSave save = null;
       PersistantSaveInfo.loadObject<PickupSave>(pathId, ref save);
       if( save != null && save.wasCollected)
        {
            gameObject.SetActive(false);
        }
    }

    void OnDestroy()
    {
        PersistantSaveInfo.StartSavingGame -= SaveData;
        itemId = 0;
    }
}

[System.Serializable]
public class PickupSave
{

    public PickupSave(bool collected)
    {
        wasCollected = collected;
    }
    public bool wasCollected;
}