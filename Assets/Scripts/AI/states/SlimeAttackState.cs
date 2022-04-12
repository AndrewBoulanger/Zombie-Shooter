using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackState : SlimeState
{
    GameObject followTarget;
    float attackRange = 3f;

    private IDamageable damageableObject;

    int attackingHash = Animator.StringToHash("isAttacking");
    int movementHash = Animator.StringToHash("isChasing");
    public SlimeAttackState(GameObject _followTarget, SlimeComponent slime, StateManager statemachine) : base(slime, statemachine)
    {
        followTarget = _followTarget;
        UpdateInterval = 2;

        damageableObject = followTarget.GetComponent<IDamageable>();
    }

    public override void Start()
    {
       //base.Start();
        Debug.Log("entered attack state start");
        ownerSlime.navMesh.isStopped = true;
        ownerSlime.navMesh.ResetPath();
        ownerSlime.animator.SetBool(movementHash, false);
        ownerSlime.animator.SetBool(attackingHash, true);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

        if (ownerSlime.animator.GetCurrentAnimatorStateInfo(0).IsTag("AttackAnim"))
            damageableObject.TakeDamage(ownerSlime.damage);
    }

    public override void Update()
    {
        if(!ownerSlime.animator.GetCurrentAnimatorStateInfo(0).IsTag("AttackAnim"))
            ownerSlime.transform.LookAt(followTarget.transform.position, Vector3.up );

        float distanceBetween = Vector3.Distance(ownerSlime.transform.position, followTarget.transform.position);
        if(distanceBetween > attackRange)
        {
            stateMachine.ChangeState(ESlimeStates.Following);
        }
    }

    public override void Exit()
    {
        base.Exit();
        ownerSlime.animator.SetBool(attackingHash, false);
        ownerSlime.navMesh.isStopped = false;
    }
}
