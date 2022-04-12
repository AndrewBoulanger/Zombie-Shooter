using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected StateManager stateMachine;

    public float UpdateInterval {get; protected set;} = 1;


    protected State(StateManager _statemachine)
    {
        stateMachine = _statemachine;
    }

    public virtual void Start()
    {

    }

    public virtual void IntervalUpdate()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }
    public virtual void Exit()
    {

    }
}
