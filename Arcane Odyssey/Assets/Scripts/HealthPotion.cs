using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    [SerializeField] private float healthValue;

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
