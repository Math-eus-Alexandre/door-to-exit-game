using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;    
    public AudioClip musicClip;

    private void Awake()
    {
        // Mantém a música ao trocar de cena
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
