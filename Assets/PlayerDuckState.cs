using UnityEngine;

public class PlayerDuckState : State
{
    private Vector3 movementAxis;
    private Rigidbody body;
    private float speed = 2f;

    public PlayerDuckState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        body = stateMachine.GetComponent<Rigidbody>();
        stateMachine.gameObject.transform.localScale = new Vector3(0.8f, 1f, 0.8f);
    }

    public override void Update()
    {
        movementAxis = HandleInput();

        body.AddForce(new Vector3(movementAxis.x, 0, movementAxis.z), ForceMode.Impulse);

        if (body.linearVelocity.magnitude > speed)
        {
            body.linearVelocity = body.linearVelocity.normalized * speed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            stateMachine.Dispose();
        }
    }

    private Vector3 HandleInput()
    {
        movementAxis.x = Input.GetAxis("Horizontal");
        movementAxis.z = Input.GetAxis("Vertical");

        return new Vector3(movementAxis.x, 0, movementAxis.z);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.gameObject.transform.localScale = Vector3.one;
    }
}
