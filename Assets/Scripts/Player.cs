using UnityEngine;

public class Player : Entity
{
    [Header("Move Info")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 7f;

    [Header("Dash Info")]
    [SerializeField] float dashDuration;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashCoolDown;
    [SerializeField]float dashTime;
    [SerializeField]float dashCoolDownTimer;



    [Header("Attack Info")]
    [SerializeField]float comboTimeWindow;
    [SerializeField] float comboTime = 0.3f;
    bool isAttacking;
    int comboCounter;

    float xInput;
    


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        Movement();
        Checkinput();
        
        if(dashTime > 0) dashTime -= Time.deltaTime;
        if(dashCoolDownTimer > 0) dashCoolDownTimer -= Time.deltaTime;
        if (comboTimeWindow > -1) comboTimeWindow -= Time.deltaTime;

        FlipController();
        AnimationControllers();

        
    }

    public void AttackOver()
    {
        isAttacking = false;

        comboCounter++;
   
        if(comboCounter > 2) comboCounter = 0;

    }



    private void Checkinput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttackEvent();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void StartAttackEvent()
    {   
        if(!isGrounded) return; 
        
        if (comboTimeWindow < 0) comboCounter = 0;

        isAttacking = true;
        comboTimeWindow = comboTime;
    }

    private void DashAbility()
    {
        if(dashCoolDownTimer <= 0 && !isAttacking)
        {
            dashCoolDownTimer = dashCoolDown;
            dashTime = dashDuration;
        }
    }

    private void Movement()
    {
        if(isAttacking)
        {
            rb.linearVelocity = new Vector2(0,0);
        }
        else if(dashTime > 0)
        {
            rb.linearVelocity = new Vector2(facingDir * dashSpeed, 0);
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
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
    }



    private void FlipController()
    {
        if (rb.linearVelocityX > 0 && !facingRight)
            Flip();
        else if (rb.linearVelocityX < 0 && facingRight)
            Flip();
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
