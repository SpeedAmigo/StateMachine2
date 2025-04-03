using UnityEngine;

public class PlayerAirAttackState : State
{
    float jumpForce = 5f;
    private Rigidbody rb;

    public PlayerAirAttackState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        rb = stateMachine.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, -jumpForce * 3, 0), ForceMode.Impulse);
    }

    public override void Update()
    {
        if (rb.linearVelocity.y == 0)
        {
            stateMachine.Begin(new PlayerGroundedState(stateMachine));
        }   
    }
}
