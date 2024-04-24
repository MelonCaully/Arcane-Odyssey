using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AizenAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] public GameObject[] spells;
    [SerializeField] private AudioClip basicSpellSound;

    public float cooldownTimer = Mathf.Infinity;
    public int attackDamage = 20; // Damage points per attack
    public Animator animator;
    public AizenMovement playerMovement;
    public Projectile ProjectilePrefab;
    private Rigidbody2D rb;
    private PolygonCollider2D coll;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<AizenMovement>();
    }

    void FixedUpdate()
    {
        // Attack input handling
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            animator.SetTrigger("Attack");
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
        SoundManager.instance.PlaySound(basicSpellSound);
        cooldownTimer = 0;

        spells[FindSpells()].transform.position = firePoint.position;
        spells[FindSpells()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindSpells()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            if (!spells[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
