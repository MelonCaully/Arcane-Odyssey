using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AizenScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 15f;
    public int n;
     private Rigidbody2D rb;
    private PolygonCollider2D coll;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) == true && n < 2)
        {
            rb.velocity = Vector2.up * jumpForce;
            n++;
        }
    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            n = 0;
        } 
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
