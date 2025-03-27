using UnityEngine;

public class PlayerGroundedState : State
{
    private Vector3 movementAxis;
    private Rigidbody body;
    private float speed = 10;

    public PlayerGroundedState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        body = stateMachine.GetComponent<Rigidbody>();
    }

    public override void Update()
    {
        movementAxis = HandleInput();
        
        body.AddForce(new Vector3(movementAxis.x, 0, movementAxis.z), ForceMode.Impulse);

        if (body.linearVelocity.magnitude > speed)
        {
            body.linearVelocity = body.linearVelocity.normalized * speed;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(new PlayerJumpState(stateMachine));
        }
    }

    private Vector3 HandleInput()
    {
        movementAxis.x = Input.GetAxis("Horizontal");
        movementAxis.z = Input.GetAxis("Vertical");

        return new Vector3(movementAxis.x, 0, movementAxis.z);
    }
}
