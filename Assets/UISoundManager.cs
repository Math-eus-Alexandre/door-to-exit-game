using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    private void Awake()
    {
        //evita que o som seja cortado quando a cena muda
        DontDestroyOnLoad(gameObject);
    }
}