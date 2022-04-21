using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);
    public static event OnWeaponEquippedEvent OnWeaponEquipped;

    public static void InvokeOnWeaponEquipped(WeaponComponent weaponComponent)
    {
        OnWeaponEquipped?.Invoke(weaponComponent);
    }


    public delegate void OnHealthInitializedEvent(HealthComponent healthComponent);
    public static event OnHealthInitializedEvent OnHealthInitialized;

    public static void Invoke_OnHealthInitialized(HealthComponent healthComponent)
    {
        OnHealthInitialized?.Invoke(healthComponent);
    }

    public delegate void OnPlayerDeathEvent();
    public static event OnPlayerDeathEvent OnPlayerDeath;

    public static void Invoke_OnPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public delegate void OnPlayerWinEvent();
    public static event OnPlayerWinEvent OnPlayerWin;

    public static void Invoke_OnPlayerWin()
    {
        OnPlayerWin?.Invoke();
    }

}
