using System.Threading;
using UnityEngine;

public class PlayerJumpState : State
{
    private Rigidbody rb;
    private float jumpForce = 5f * 100;

    private float time = 0; 

    public PlayerJumpState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        rb = stateMachine.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0f, jumpForce, 0f));
    }

    public override void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.SetState(new PlayerAirAttackState(stateMachine));
        }

        if (time < 0.2f)
        {
            time += Time.deltaTime;
            return;
        }

        JumpRaycast();
    }

    private void JumpRaycast()
    {
        if (Physics.Raycast(stateMachine.transform.position, Vector3.down, 0.5f))
        {
            stateMachine.Begin(new PlayerGroundedState(stateMachine));
        }
    }
}
