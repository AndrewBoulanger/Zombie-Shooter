using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealEffect", menuName = "Effects/heal")]
public class HealPlayerEffect : EffectsScript
{
    
    //_amount will be overwriten by scriptable object amount if set
    public override bool ApplyEffect(PlayerController player, int _amount)
    {
        HealthComponent pHealth = player?.GetComponent<HealthComponent>();
        if(pHealth == null || pHealth.CurrentHealth == pHealth.MaxHealth)
            return false;
        

        if(amount > -1)
            _amount = amount;

        pHealth.Heal(_amount);

        return true;
    }
}
