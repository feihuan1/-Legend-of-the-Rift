using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 7f;

    [Header("Dash Info")]
    [SerializeField] float dashDuration;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashCoolDown;

    [Header("Collision Info")]
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator anim;

    float xInput;
    bool isGrounded;
    int facingDir = 1;
    bool facingRight = true;
    [SerializeField]float dashTime;
    [SerializeField]float dashCoolDownTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Movement();
        Checkinput();
        CollisionChecks();

        
        if(dashTime > 0) dashTime -= Time.deltaTime;
        if(dashCoolDownTimer > 0) dashCoolDownTimer -= Time.deltaTime;

        FlipController();
        AnimationControllers();
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void Checkinput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void DashAbility()
    {
        if(dashCoolDownTimer <= 0)
        {
            dashCoolDownTimer = dashCoolDown;
            dashTime = dashDuration;
        }
    }

    private void Movement()
    {
        if(dashTime > 0)
        {
            rb.linearVelocity = new Vector2(xInput * dashSpeed, 0);
        }
        else{
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        }
    }

    private void Jump()
    {
        if(isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void AnimationControllers()
    {
        bool isMoving = rb.linearVelocityX != 0;
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.linearVelocityY);
        anim.SetBool("isDashing", dashTime > 0);
    }

    private void FlipPlayer()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if (rb.linearVelocityX > 0 && !facingRight)
            FlipPlayer();
        else if (rb.linearVelocityX < 0 && facingRight)
            FlipPlayer();
    }

// // debug function, draw a line in scene
//     private void OnDrawGizmos()
//     {
//         Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
//     }

    private static void TwoWayGetAxisInput()
    {
        // get float
        // Debug.Log(Input.GetAxis("Horizontal"));
        // Debug.Log(Input.GetAxis("Vertical"));

        // get int
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        Debug.Log(Input.GetAxisRaw("Vertical"));
    }
    private static void TwoWayGetSingleKey()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Holding AAA");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Key up s");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
        }

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jumpping");
        }
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("Jump finnally");
        }
    }
}
