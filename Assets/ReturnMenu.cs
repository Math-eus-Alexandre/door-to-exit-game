using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoVoltar : MonoBehaviour
{
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
