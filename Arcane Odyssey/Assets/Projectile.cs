using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime* speed;
    }

    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
