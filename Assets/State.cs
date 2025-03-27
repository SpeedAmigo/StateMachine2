using UnityEngine;

public abstract class State
{
    protected StateMachine stateMachine;

    public State(StateMachine machine)
    {
        stateMachine = machine;
    }


    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
