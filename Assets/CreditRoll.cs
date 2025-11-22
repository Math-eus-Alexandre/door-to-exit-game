using UnityEngine;

public class CreditRoll : MonoBehaviour
{
    public float speed = 1.5f;
    public float startY = -600f;  // posição abaixo da tela
    public float endY = 2250f;     // posição acima da tela

    void Start()
    {
        // faz o texto a começar de baixo
        Vector3 pos = transform.localPosition;
        pos.y = startY;
        transform.localPosition = pos;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // reset para loop
        if (transform.localPosition.y >= endY)
        {
            Vector3 pos = transform.localPosition;
            pos.y = startY;
            transform.localPosition = pos;
        }
    }
}
