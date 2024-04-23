using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private float activationDelay;
    private Animator animator;
    private SpriteRenderer spriteRend;
    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Awake()
    {
        activationDelay = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
