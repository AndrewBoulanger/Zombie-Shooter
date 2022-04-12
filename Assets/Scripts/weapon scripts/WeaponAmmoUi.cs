using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponAmmoUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI weaponNameText;
    [SerializeField] TextMeshProUGUI ArrowCountText;
    
    [SerializeField] WeaponHolder weaponHolder;
  
    // Update is called once per frame
    void Update()
    {
        if(!weaponHolder)
            return;

        weaponNameText.text = weaponHolder.equippedWeapon.weaponStats.weaponName;
        ArrowCountText.text = weaponHolder.AmmoCount.ToString();
    }
}
