using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float range;
    [SerializeField] private PolygonCollider2D polygonCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
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
    }

    bool  PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(polygonCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(polygonCollider.bounds.size.x * range, polygonCollider.bounds.size.y,polygonCollider.bounds.size.z), 
        0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(polygonCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(polygonCollider.bounds.size.x * range, polygonCollider.bounds.size.y,polygonCollider.bounds.size.z));
    }
}
