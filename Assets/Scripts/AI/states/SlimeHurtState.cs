using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHurtState : SlimeState
{
    int hitHash = Animator.StringToHash("onHit");
    float Hitforce = 5f;
    
    public SlimeHurtState(SlimeComponent slime, StateManager statemachine) : base(slime, statemachine)
    {
        UpdateInterval = 1;
    }

    public override void Start()
    {
        base.Start();
        if(ownerSlime.navMesh.isStopped)
            ownerSlime.navMesh.velocity = ownerSlime.transform.forward * Hitforce * -1;
        else
            ownerSlime.navMesh.velocity *= -1;
        ownerSlime.navMesh.isStopped = true;
        ownerSlime.navMesh.ResetPath();
        ownerSlime.animator.SetTrigger(hitHash);
    }

    public override void IntervalUpdate()
    {
        if (!ownerSlime.animator.GetCurrentAnimatorStateInfo(0).IsTag("hurt"))
            ownerSlime.stateMachine.ChangeState(ESlimeStates.Following);
    }

    public override void Exit()
    {
        base.Exit();
        ownerSlime.navMesh.isStopped = false;
    }
}
