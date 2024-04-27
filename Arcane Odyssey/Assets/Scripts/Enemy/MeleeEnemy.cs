using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float damage;
    [SerializeField] private float range;

    [Header ("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private PolygonCollider2D polygonCollider;

    [Header ("player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator animator;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
       cooldownTimer += Time.deltaTime; 

       if (PlayerInSight())
       {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                animator.SetTrigger("Attack");
            }
       }

       if (enemyPatrol != null)
       {
        enemyPatrol.enabled = !PlayerInSight();
       }
    }

    bool  PlayerInSight()
    {
        RaycastHit2D hit = 
        Physics2D.BoxCast(polygonCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(polygonCollider.bounds.size.x * range, polygonCollider.bounds.size.y, polygonCollider.bounds.size.z), 
        0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(polygonCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(polygonCollider.bounds.size.x * range, polygonCollider.bounds.size.y,polygonCollider.bounds.size.z));
    }

    void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
