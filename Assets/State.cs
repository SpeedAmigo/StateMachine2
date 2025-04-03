using System;
using UnityEngine;

[Serializable]
public class State
{
    public string name;
    protected StateMachine stateMachine;

    public State(StateMachine machine)
    {
        name = GetType().Name;
        stateMachine = machine;
    }


    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
