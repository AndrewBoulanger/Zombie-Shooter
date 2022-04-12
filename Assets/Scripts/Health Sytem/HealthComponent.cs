using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float currentHealth, maxHealth;
    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
            Destroy();

        print(gameObject.name + " health: " + currentHealth);
    }

}
