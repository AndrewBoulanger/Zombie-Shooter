using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowComponent : WeaponComponent
{

    protected bool isDrawingArrow;
    protected float drawTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDrawingArrow)
        {
            drawTimer += Time.deltaTime;
        }
    }

    public override void Shoot()
    {
        List<Vector3> hitLocations = new List<Vector3>();

        if(drawTimer >= weaponStats.drawTime)
        { 
            base.Shoot();
            isDrawingArrow = false;
            drawTimer = 0;
            
            Ray screenRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height *0.5f));

            RaycastHit[] hits;

            if(weaponStats.isPiercing)
            { 
                  hits = Physics.RaycastAll(screenRay, weaponStats.distance, weaponStats.weaponHitLayer);
                  if(hits.Length == 0) return;
            }
            else
            {
                if (!Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.distance, weaponStats.weaponHitLayer)) return;

                hits = new RaycastHit[] { hit };
            }

            foreach(RaycastHit hit in hits)
            {
 
                hitLocations.Add(hit.point);

                Debug.DrawLine(transform.position, hit.point, Color.red, 2.0f);

                arrowHitEffect.transform.position = hit.point;
                DealDamage(hit);
            }
        }

        
    }

    void DealDamage(RaycastHit hitInfo)
    {
        IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();
        damageable?.TakeDamage(weaponStats.damage);
    }


    public override void StartDrawingArrow()
    {
        isDrawingArrow = true;

    }
}
