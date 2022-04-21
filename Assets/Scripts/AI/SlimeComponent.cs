using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(StateManager))]
public class SlimeComponent : MonoBehaviour
{

    public float damage = 50;

    public NavMeshAgent navMesh;
    public Animator animator;
    public StateManager stateMachine;
    public GameObject followTarget;

    public delegate void OnSlimeDeathDelegate(SlimeComponent slime);
    public static event OnSlimeDeathDelegate OnSlimeDeath;

    public void InvokeOnSlimeDeath()
    {
        OnSlimeDeath?.Invoke(this);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        stateMachine = GetComponent<StateManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(followTarget)
            Initialize(followTarget);
        
    }


    public void Initialize(GameObject _followTarget)
    {
        followTarget = _followTarget;
        stateMachine.AddState(ESlimeStates.Idle, new SlimeIdleState(this, stateMachine));
        stateMachine.AddState(ESlimeStates.Attacking, new SlimeAttackState(followTarget, this, stateMachine));
        stateMachine.AddState(ESlimeStates.Following, new SlimeFollowState(followTarget, this, stateMachine));
        stateMachine.AddState(ESlimeStates.IsHurt, new SlimeHurtState(this, stateMachine));
        stateMachine.AddState(ESlimeStates.IsDead, new SlimeDeadState(this, stateMachine));

        stateMachine.Initialize(ESlimeStates.Following);
    }

    
}
