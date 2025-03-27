using UnityEngine;

public class PlayerJumpState : State
{
    private Rigidbody rb;
    private float jumpForce = 5f;

    public PlayerJumpState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        rb = stateMachine.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0f, jumpForce * 100, 0f));
    }

    public override void Update() 
    {
        JumpRaycast();
    }

    private void JumpRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(stateMachine.transform.position, Vector3.down, 0.5f))
        {
            stateMachine.Begin(new PlayerGroundedState(stateMachine));
        }
    }
}
