using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private PlayerHealth playerHealth;
    private UIManager uiManager;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        if (currentCheckpoint == null)
        {
            SoundManager.instance.StopBackgroundMusic();
            uiManager.GameOver();
            return;
        }

        playerHealth.Respawn();
        transform.position = currentCheckpoint.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("Activate");
        }
    }
}
