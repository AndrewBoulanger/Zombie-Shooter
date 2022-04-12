using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCriticalHitComponent : HealthComponent
{
    [SerializeField] HealthComponent parenthealth;


    public override void TakeDamage(float damage)
    {
        parenthealth?.TakeDamage(damage * 3);
    }
}
