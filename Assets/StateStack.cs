using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StateStack
{
    private List<State> stack = new();

    public void Push(State state)
    {
        stack.Add(state);
    }

    public State Pop()
    {
        State lastState = Peek();
        stack.RemoveAt(stack.Count - 1);
        return lastState;
    }

    public State Peek()
    {
        if (stack.Count == 0)
        {
            return null;
        }

        return stack[stack.Count - 1];
    }

    public int Count()
    {
        return stack.Count;
    }

    public List<State> GetStack()
    {
        return stack;
    }
}
