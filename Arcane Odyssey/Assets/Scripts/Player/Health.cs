using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    private bool dead;
    public float currentHealth;
    private Animator animator;
    private Rigidbody2D rb;

    [Header ("iFrames")]
    [SerializeField] private float iDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
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
            StartCoroutine(Invulnerability());
        } 
        else
        {
            if (!dead)
            {
                animator.SetTrigger("Dead");
                GetComponent<AizenMovement>().enabled = false;
                 GetComponent<AizenAttack>().enabled = false;
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

    IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
        spriteRend.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(iDuration / (numberOfFlashes * 2));
        spriteRend.color = Color.white;
        yield return new WaitForSeconds(iDuration / (numberOfFlashes * 2));
        }     
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
