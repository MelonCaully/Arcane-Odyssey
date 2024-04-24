using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private float activationDelay; // Default delay set to 3 seconds
    private float activationTime;
    private Animator animator;
    private bool activated;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        activated = false;
        if (!activated)
        {
            activationTime -= Time.deltaTime; // Decrease the delay by the time passed in this frame
            if (activationTime <= 0)
            {
                Activate();
            } 
        }
    }

    void Activate()
    {
        animator.SetTrigger("Active");
        activated = true;
        activationTime = activationDelay;
        boxCollider.enabled = true;
    }

    void Deactivate()
    {
        boxCollider.enabled = false;
    }
}
