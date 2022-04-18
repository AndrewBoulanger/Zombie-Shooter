using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public State currentState{get; private set;} 

    protected Dictionary<ESlimeStates, State> states;
    bool isRunning;

    void Awake()
    {
        states = new Dictionary<ESlimeStates, State>();
    }

    public void Initialize(ESlimeStates startingState)
    {
        if(states.ContainsKey(startingState))
        {
            ChangeState(startingState);
        }
    }

    public void AddState(ESlimeStates stateName, State state)
    {
        if(states.ContainsKey(stateName)) return;
        states.Add(stateName, state);
    }

    public void RemoveState(ESlimeStates stateName)
    {
        if (!states.ContainsKey(stateName)) return;
        states.Remove(stateName);
    }


    public void ChangeState(ESlimeStates newState)
    {
        if(isRunning)
        {
            StopRunningState();
        }
        if(!states.ContainsKey(newState)) return;

        currentState = states[newState];
        currentState.Start();

        if(currentState.UpdateInterval > 0)
        {
            InvokeRepeating(nameof(IntervalUpdate), 0, currentState.UpdateInterval);
        }
        isRunning = true;
    }

    void StopRunningState()
    {
        isRunning = false;
        currentState.Exit();
        CancelInvoke(nameof(IntervalUpdate));
    }

    private void IntervalUpdate()
    {
        if(isRunning)
            currentState.IntervalUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning)
            currentState.Update();
    }
}
