using UnityEngine;

public class ThreeBehavior : MonoBehaviour
{
    public float speed = 10f;
    public float floatSpeed = 5f;
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        // Set gravity scale to 0 for floating behavior
        rb.gravityScale = 0f;
    }

    void Update()
    {
        // Horizontal movement
        float horizontalMove = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove = -0.3f;
            spriteRenderer.flipX = true;
            animator.enabled = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMove = 0.3f;
            spriteRenderer.flipX = false;
            animator.enabled = true;
        }
        else
        {
            animator.enabled = false;
        }

        // Vertical movement
        float verticalMove = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            verticalMove = floatSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalMove = -floatSpeed;
        }

        // Apply movement
        rb.linearVelocity = new Vector2(horizontalMove * speed, verticalMove);
    }
}