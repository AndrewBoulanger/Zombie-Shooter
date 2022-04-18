using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthInfoUI : MonoBehaviour
{
    public Slider healthSlider;
    HealthComponent PlayerHealth;
    int maxhealth;


    
    private void PlayerEvents_OnHealthInitialized(HealthComponent healthComponent)
    {
        PlayerHealth = healthComponent;
        healthSlider.maxValue = healthComponent.MaxHealth;
    }
    private void OnEnable()
    {
        PlayerEvents.OnHealthInitialized += PlayerEvents_OnHealthInitialized;
    }
    private void OnDisable()
    {
        PlayerEvents.OnHealthInitialized -= PlayerEvents_OnHealthInitialized;
    }

    private void Update()
    {
        healthSlider.value = PlayerHealth.CurrentHealth;
    }
}
