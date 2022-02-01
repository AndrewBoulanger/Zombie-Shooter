using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [Header("Weapon To Spawn"), SerializeField]
    GameObject weaponToSpawn;

    PlayerController playerController;

    Sprite crosshairImage;

    [SerializeField]
    Transform weaponSocket;


    private void Start()
    {
        GameObject spawnObject = Instantiate(weaponToSpawn, weaponSocket.position, weaponSocket.rotation, weaponSocket);
    }
}
