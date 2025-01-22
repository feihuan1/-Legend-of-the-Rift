using UnityEngine;

public class EnemySkeleton : Entity
{
    bool isAttacking;

    [Header("Move info")]
    [SerializeField] private float moveSpeed;

    [Header("Player Detection")]
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;

    private RaycastHit2D isPlayerDetected;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (isPlayerDetected.distance > 1)
        {
            rb.linearVelocity = new Vector2(moveSpeed * 1.5f * facingDir, rb.linearVelocityY);
            Debug.Log("I C U");
            isAttacking = false;
        }
        else
        {
            Debug.Log(isPlayerDetected.distance);
            Debug.Log(isAttacking);
            isAttacking = true;
        }

        if (!isGrounded || isWallDetected) 
            Flip();

        Movement();
    }

    private void Movement()
    {
        if(!isAttacking)
            rb.linearVelocity = new Vector2(moveSpeed * facingDir, rb.linearVelocityY);
    }

    protected override void CollisionChecks()
    {
        base.CollisionChecks();

        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDir, whatIsPlayer);

    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + playerCheckDistance * facingDir, transform.position.y));
    }
}
