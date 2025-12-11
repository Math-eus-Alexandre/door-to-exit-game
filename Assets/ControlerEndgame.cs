using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerEndgame : MonoBehaviour
{
    public TimerController timer;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TimerController.Instance.StopTimer();
            Debug.Log("Timer parado!"); 
        }
    }
    
}
