using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private StateStack stack;
    public State CurrentState {  get; private set; }
    private State previousState;

    public void Begin(State state)
    {
        stack = new StateStack();
        stack.Push(state);
        CurrentState = state;
        CurrentState.Enter();
    }

    public void SetState(State state)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
        }

        CurrentState = state;
        stack.Push(state);
        CurrentState.Enter();
    }

    public void Dispose()
    {
        if (stack.Count() == 0)
        {
            return;
        }

        CurrentState.Exit();
        CurrentState = null;
        stack.Pop();

        if (stack.Count() == 0)
        {
            return;
        }

        CurrentState = stack.Peek();
        CurrentState.Enter();
    }

    private void Update()
    {
        if (CurrentState == null) return;

        CurrentState.Update();
    }
}
