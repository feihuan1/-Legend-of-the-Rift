using UnityEngine;

public class Player : MonoBehaviour
{
    float xInput;
    float yInput;
    float moveSpeed = 5f;
    float jumpForce = 7f;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // TwoWayGetSingleKey();
        // TwoWayGetAxisInput();
        xInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }


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
