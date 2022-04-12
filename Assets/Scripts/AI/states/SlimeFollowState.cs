using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFollowState : SlimeState
{
    GameObject followTarget;
    int movementHash = Animator.StringToHash("isChasing");
    const float stoppingDistance = 2.5f;

    public SlimeFollowState(GameObject _followTarget, SlimeComponent slime, StateManager statemachine) : base(slime, statemachine)
    {
        followTarget = _followTarget;
        UpdateInterval = 2;    

    }

    public override void Start()
    {
        base.Start();
        ownerSlime.navMesh.SetDestination(followTarget.transform.position);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        ownerSlime.navMesh.SetDestination(followTarget.transform.position);
    }

    public override void Update()
    {
        base.Update();
        bool isMoving = ownerSlime.navMesh.velocity.z != 0f ;
        ownerSlime.animator.SetBool(movementHash, isMoving);

        float distanceBetween = Vector3.Distance(ownerSlime.transform.position, followTarget.transform.position);
        if(distanceBetween < stoppingDistance)
        {
            stateMachine.ChangeState(ESlimeStates.Attacking);
        }
    }

    public override void Exit()
    {
        base.Exit();
        ownerSlime.animator.SetBool(movementHash, false);
        ownerSlime.navMesh.isStopped = true;
    }
}
