using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    none, bow
}

[System.Serializable]
public struct WeaponStats
{
   public WeaponType weaponType;
    public string weaponName;
    public float damage;
    public int arrowsPerShot;
    public float drawTime;
    public float distance;
    public bool isPiercing;

    public LayerMask weaponHitLayer;
}


public class WeaponComponent : MonoBehaviour
{
    public Transform ikGripLocation;

    protected WeaponHolder weaponHolder;

    protected bool isReloading;
    
    protected Camera mainCamera;
    [SerializeField]
    protected ParticleSystem arrowHitEffect;

    [SerializeField]
    public WeaponStats weaponStats;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(WeaponHolder _weaponHolder)
    {
        weaponHolder = _weaponHolder;
    }

    public virtual void Shoot()
    {
        isReloading = true;
    }

    public virtual void StartDrawingArrow()
    {

    }


}
