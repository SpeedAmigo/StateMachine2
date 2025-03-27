using UnityEngine;

public class Player : StateMachine
{
    private void Start()
    {
        Begin(new PlayerGroundedState(this));
    }
}
