using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine
{
    private Dictionary<string, AIState> states = new Dictionary<string, AIState>();
    public AIState CurrentState { get; private set; } = null;
    public void Update()
    {
        CurrentState?.OnUpdate();
    }

    public void AddState(string name, AIState state)
    {
        Debug.Assert(!states.ContainsKey(name), "State machine already contains state " + name);
        states[name] = state;
    }

    public void SetState(string name)
    {
        Debug.Assert(states.ContainsKey(name), "State machine does not contain state " + name);

        var newState = states[name];

        // don't reenter same state
        if (CurrentState == newState) return;

        // exit current state
        CurrentState?.OnExit();
        // set new state
        CurrentState = newState;
        // enter current state
        CurrentState?.OnEnter();

        //AIState state = states[name];
        //if (state == CurrentState) return;

        //CurrentState?.OnExit();
        //CurrentState = state;
        //CurrentState?.OnEnter();
    }
}
