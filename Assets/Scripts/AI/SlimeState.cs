using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeState : State
{
    protected SlimeComponent ownerSlime;
   public SlimeState(SlimeComponent slime, StateManager stateMachine) : base(stateMachine)
    {
        ownerSlime = slime;
    }


}


public enum ESlimeStates
{
    Idle, Attacking, Following, IsHurt, IsDead
}