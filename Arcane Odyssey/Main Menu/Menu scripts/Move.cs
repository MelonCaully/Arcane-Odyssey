using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] Vector2 moveDirection;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int xcount;
    [SerializeField] int ycount;

    void FixedUpdate()
    {
        MoveObject();
    }

    void MoveObject()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "North")
        {
            moveDirection.y = Random.Range(-2, 0);

            Debug.Log("Hit boundary");
        }
        if (collision.gameObject.tag == "South")
        {
            moveDirection.y = Random.Range(1, 3);

            Debug.Log("Hit boundary");
        }
        if (collision.gameObject.tag == "East")
        {

            moveDirection.x = Random.Range(-2, 0);

            Debug.Log("Hit boundary");
        }
        if (collision.gameObject.tag == "West")
        {

            moveDirection.x = Random.Range(1, 3);
            Debug.Log("Hit boundary");
        }
    }
}