using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectsScript : ScriptableObject
{
    public int amount = -1;

    public abstract bool ApplyEffect(PlayerController player, int _amount);
}
