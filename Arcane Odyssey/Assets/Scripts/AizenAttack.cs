using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AizenAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePointl;
    [SerializeField] public GameObject[] spells;
    public float cooldownTimer = Mathf.Infinity;
    public int attackDamage = 20; // Damage points per attack
    public Animator animator;
    public AizenMovement playerMovement;
    public Projectile ProjectilePrefab;
    public Transform LaunchOffset;
    private Rigidbody2D rb;
    private PolygonCollider2D coll;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<AizenMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Attack input handling
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        } 
    }

    void FixedUpdate()
    {
        // Attack input handling
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            Attack();
        } 
        else 
        {
            animator.ResetTrigger("Attack");
        }
        cooldownTimer += Time.deltaTime;
    }

    // Function to perform attack
    void Attack()
    {
        animator.SetTrigger("Attack");
        cooldownTimer = 0;

        spells[0].transform.position = firePointl.position;
        spells[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
