using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupComponent : MonoBehaviour
{
    [SerializeField]
    ItemScript pickupItem;

    [SerializeField]
    int amount = -1;

    [SerializeField] MeshRenderer PropMeshRenderer;
    [SerializeField] MeshFilter propMeshFilter;

    ItemScript itemInstance;

    static bool rotated = false;
    static Vector3 yRot = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
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

    private void LateUpdate()
    {
        rotated = false;
    }

    private void Update()
    {
        rotate();
        transform.Rotate(yRot);
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

        Destroy(gameObject);
    }

    static void rotate()
    {
        if(!rotated)
        { 
            rotated = true;
            yRot = Vector3.up * Time.deltaTime * 50f; 
        }
    }

}
