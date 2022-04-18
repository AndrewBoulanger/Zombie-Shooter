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

    // Start is called before the first frame update
    void Start()
    {
        InstantiateItem();
    }
    private void InstantiateItem()
    {
        itemInstance = Instantiate(pickupItem);
        if(amount > 0)
        {
            itemInstance.SetAmount(amount);
        }
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



        Destroy(gameObject);
    }
}
