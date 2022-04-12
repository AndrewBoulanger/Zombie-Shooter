using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDeadState : SlimeState
{
    int deathHash = Animator.StringToHash("isDead");
    int movementHash = Animator.StringToHash("isChasing");
    public SlimeDeadState(SlimeComponent slime, StateManager statemachine) : base(slime, statemachine)
    {

    }

    public override void Start()
    {
        base.Start();
        ownerSlime.navMesh.isStopped = true;
        ownerSlime.navMesh.ResetPath();
        ownerSlime.animator.SetBool(movementHash, false);
        ownerSlime.animator.SetBool(deathHash, true);
    }

    public override void Exit()
    {
        base.Exit();
        ownerSlime.navMesh.isStopped = false;
        ownerSlime.animator.SetBool(deathHash, false);
    }
}
