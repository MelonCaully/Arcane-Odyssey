using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
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

    [Header ("Components")]
     [SerializeField] private Behaviour[] components;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            animator.SetTrigger("Hit");
            StartCoroutine(Invulnerability());
        } 
        else
        {
            if (!dead)
            {
                animator.SetTrigger("Dead");

                // Deactivate all attached components
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                dead = true;
            }
        }
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

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

