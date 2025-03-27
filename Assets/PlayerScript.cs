using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float raycastLength;
    public float jumpForce;

    private Rigidbody rb;

    private Vector3 movementAxis;
    private bool isJumping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movementAxis = HandleInput();

        Jump();
        Crouch();
        AirAttack();
        JumpRaycast();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector3(0f, jumpForce * 100, 0f));
        }
    }

    private Vector3 HandleInput()
    {
        movementAxis.x = Input.GetAxis("Horizontal");
        movementAxis.z = Input.GetAxis("Vertical");

        return new Vector3(movementAxis.x, 0, movementAxis.z);
    }

    private void JumpRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, raycastLength))
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }
    }

    private void AirAttack()
    {
        if ( isJumping && Input.GetMouseButtonDown(0))
        {
            rb.AddForce(new Vector3(0, -jumpForce * 3, 0), ForceMode.Impulse);
        }
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            gameObject.transform.localScale = new Vector3(0.8f, 1f, 0.8f);
        }
        else
        {
            gameObject.transform.localScale = Vector3.one;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(movementAxis.x, 0, movementAxis.z), ForceMode.Impulse);

        if (rb.linearVelocity.magnitude > speed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }
}
