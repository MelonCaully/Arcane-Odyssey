using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private UIManager uiManager;
    private Animator animator;
    private bool finish;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;

    // Start is called before the first frame update
    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        animator = GetComponent<Animator>();

        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
    }

    void CheckFinish()
    {
        if (finish)
        {
            SoundManager.instance.StopBackgroundMusic();
            uiManager.Victory();
            finish = false;

            return;
        }

        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finish = true;
            animator.SetTrigger("Finish");
        }
    }
}
