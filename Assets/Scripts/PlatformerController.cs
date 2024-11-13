using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float decceleration = 50f;
    [SerializeField] private float velocityPower = 0.9f;
    
    [Header("Jump")]
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float jumpCutMultiplier = 0.5f;
    [SerializeField] private float fallGravityMultiplier = 1.7f;
    [SerializeField] private float maxFallSpeed = 18f;
    [SerializeField] private float coyoteTime = 0.1f;
    [SerializeField] private float jumpBufferTime = 0.1f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);
    [SerializeField] private LayerMask groundLayer;

    // Component references
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Movement variables
    private float moveInput;
    private float lastGroundedTime;
    private float lastJumpTime;
    public bool isJumping;
    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Get horizontal input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Ground check
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);

        // Coyote time
        if (isGrounded)
        {
            lastGroundedTime = coyoteTime;
            isJumping = false;
        }
        else
        {
            lastGroundedTime -= Time.deltaTime;
        }

        // Jump buffer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lastJumpTime = jumpBufferTime;
        }
        else
        {
            lastJumpTime -= Time.deltaTime;
        }

        // Jump
        if (lastJumpTime > 0f && lastGroundedTime > 0f && !isJumping)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            lastJumpTime = 0f;
        }

        // Jump cut (for variable jump height)
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutMultiplier);
        }

        // Flip sprite based on movement direction
        if (moveInput != 0)
        {
            spriteRenderer.flipX = moveInput < 0;
        }
    }

    private void FixedUpdate()
    {
        // Calculate target speed
        float targetSpeed = moveInput * moveSpeed;
        
        // Calculate speed difference
        float speedDiff = targetSpeed - rb.velocity.x;
        
        // Calculate acceleration rate
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        
        // Calculate movement force
        float movement = Mathf.Pow(Mathf.Abs(speedDiff) * accelRate, velocityPower) * Mathf.Sign(speedDiff);
        
        // Apply movement force
        rb.AddForce(movement * Vector2.right);

        // Apply extra gravity when falling
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityMultiplier;
            // Clamp fall speed
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnDrawGizmos()
    {
        // Draw ground check area in editor
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
        }
    }
}