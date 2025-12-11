using UnityEngine;

public class GateFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TimerController.Instance.FinalizarTempo();
        }
    }
}