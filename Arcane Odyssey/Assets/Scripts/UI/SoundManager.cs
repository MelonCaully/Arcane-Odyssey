using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    public static SoundManager instance;
    private AudioSource source;

    void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        // Play background music when the SoundManager is created
        PlayBackgroundMusic();
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }

    public void PlayBackgroundMusic()
    {
        source.clip = backgroundMusic;
        source.loop = true;
        source.Play();
    }

    public void StopBackgroundMusic()
    {
        source.Stop();
    }
}