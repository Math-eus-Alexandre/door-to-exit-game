using UnityEngine;
using UnityEngine.SceneManagement;

public class GateFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se quem bateu foi o player
        if (collision.CompareTag("Player"))
        {
            // Finaliza o tempo e registra no Top 5
            TimerController.Instance.FinalizarTempo();

            SceneManager.LoadScene("Top5");
        }
    }
}