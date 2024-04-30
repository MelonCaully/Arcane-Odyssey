using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Move speed
    public float jumpForce = 15f; // Jump speed
    public int numberOfJumps;
    [SerializeField] private AudioClip jump;
    public Animator animator;
    private Rigidbody2D rb;
    private PolygonCollider2D coll;
    //private bool isGrounded; // Flag determines if touching ground
    private Vector3 initialScale;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Flip character sprite only when changing direction
        if (moveInput < 0 && transform.localScale.x > 0) // Moving left
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else if (moveInput > 0 && transform.localScale.x < 0) // Moving right
        {
            transform.localScale = initialScale;
        }

        // Vertical Movement
        if (Input.GetKeyDown(KeyCode.Space) == true && numberOfJumps < 2)
        {
            Jump();
        } 
        else if (rb.velocity.y < -1) // Falling
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else if (rb.velocity.y > -1) // Not Falling
        {
            animator.SetBool("isFalling", false);
        }

        // Adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //isGrounded = true;
            numberOfJumps = 0;
            animator.SetBool("isGrounded", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

    // Function to handle jump
    void Jump()
    {
            SoundManager.instance.PlaySound(jump);
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
            numberOfJumps++;
    }
}
