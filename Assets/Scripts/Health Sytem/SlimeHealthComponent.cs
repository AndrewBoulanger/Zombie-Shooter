using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealthComponent : HealthComponent
{
    StateManager stateMachine;
    
    

    private void Awake()
    {
        stateMachine = GetComponent<StateManager>();
    }

    public override void Destroy()
    {
        stateMachine.ChangeState(ESlimeStates.IsDead);
    }

    public override void TakeDamage(float damage)
    {
        stateMachine.ChangeState(ESlimeStates.IsHurt);
        base.TakeDamage(damage);
    }
}
