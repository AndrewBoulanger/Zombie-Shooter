using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotEquippedCanvas : MonoBehaviour
{
    EquippableScript Equipable;
    [SerializeField] private Image EnabledImage;

    private void Awake()
    {
        HideWidget();
    }

    public void ShowWidget()
    {
        gameObject.SetActive(true);
    }

    public void HideWidget() 
    {
        gameObject.SetActive(false);
    }


    public void Initialize(ItemScript item)
    {
        if (!(item is EquippableScript eqItem)) return;

        Equipable = eqItem;
        ShowWidget();
        Equipable.OnEquippedStatusChange += OnEquipmentChange;
        OnEquipmentChange();

    }

    private void OnEquipmentChange()
    {
        EnabledImage.gameObject.SetActive(Equipable.Equipped);
    }

    private void OnDisable()
    {
        if (Equipable) 
            Equipable.OnEquippedStatusChange -= OnEquipmentChange;
    }
}
