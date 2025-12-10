using UnityEngine;

public class Walking : MonoBehaviour
{
    public AudioSource audioSource;
    public Rigidbody2D rb;

    [Header("Configurações")]
    public float minSpeed = 0.1f;

    void Update()
    {
        float speed = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y);

        bool isWalking = speed > minSpeed;

        if (isWalking)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }
}
