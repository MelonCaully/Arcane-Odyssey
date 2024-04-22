using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private bool dead;
    public float currentHealth;
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            animator.SetTrigger("Hurt");
        } 
        else
        {
            if (!dead)
            {
                animator.SetTrigger("Dead");
                GetComponent<AizenMovement>().enabled = false;
                dead = true;
                rb.velocity = Vector2.zero; // Reset the velocity to zero
                rb.isKinematic = true;
                rb.gravityScale = 1f; 
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
