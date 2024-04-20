using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AizenScript : MonoBehaviour
{
    public float moveSpeed = 10f; // Move speed
    public float jumpForce = 15f; // Jump speed
    public int n;
    public int maxHealth = 100; // Max health points
    public int currentHealth; // Current health points
    public int attackDamage = 20; // Damage points per attack
    public float attackRate = 0.5f; // Attack rate in attacks per second
    public float nextAttackTime = 0f; // Time to perform the next attack
    public Animator animator;
    public Projectile ProjectilePrefab;
    public Transform LaunchOffset;
    private Rigidbody2D rb;
    private PolygonCollider2D coll;
    private bool isGrounded; // Flag determines if touching ground
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
        initialScale = transform.localScale;
        currentHealth = maxHealth;
        animator.SetBool("Death", false);
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
        if (Input.GetKeyDown(KeyCode.Space) == true && n < 2)
        {
            Jump();
        } 
        else if (rb.velocity.y < -1) // Falling
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }

         // Attack input handling
        if (Input.GetMouseButton(0) && Time.time >= nextAttackTime)
        {
            animator.SetBool("Attack", true);
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            nextAttackTime = Time.time + 1f / attackRate;
        } 
    }

    void FixedUpdate()
    {
        // Attack input handling
        if (Input.GetMouseButton(0) && Time.time >= nextAttackTime)
        {
            Attack();
        } 
        else 
        {
            animator.ResetTrigger("Attack");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            n = 0;
            isGrounded = true;
            animator.SetBool("isFalling", false);
            animator.SetBool("isGrounded", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

    // Function to handle jump
    void Jump()
    {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
            n++;
    }

// Function to perform attack
    void Attack()
    {
        animator.SetTrigger("Attack");
        nextAttackTime = Time.time + 1f / attackRate;
    }

    // Function to reduce health
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("Death", true);
    }

    // Function to heal
   void Heal(int amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }
}
