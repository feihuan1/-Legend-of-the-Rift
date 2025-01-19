using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 7f;

    float xInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Movement();
        Checkinput();

        if(Input.GetKeyDown(KeyCode.R)) FlipPlayer();

        AnimationControllers();
    }

    private void Checkinput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Movement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void AnimationControllers()
    {
        bool isMoving = rb.linearVelocityX != 0;

        anim.SetBool("isMoving", isMoving);
    }

    private void FlipPlayer()
    {
        transform.Rotate(0, 180, 0);
    }




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
