using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState : SlimeState
{
    int movementHash = Animator.StringToHash("isChasing");
    
    public SlimeIdleState(SlimeComponent slime, StateManager statemachine) : base(slime, statemachine)
    {

    }

    public override void Start()
    {
        base.Start();
        ownerSlime.navMesh.isStopped = true;
        ownerSlime.navMesh.ResetPath();
        ownerSlime.animator.SetBool(movementHash, false);
    }

    public override void Exit()
    {
        base.Exit();
        ownerSlime.navMesh.isStopped = false;
    }
}
