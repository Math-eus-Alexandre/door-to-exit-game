using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        // Carrega a fase principal
        SceneManager.LoadScene("Jogo");
    }

    public void OpenTop5()
    {
        // Abre a tela de tempos
        SceneManager.LoadScene("Top5");
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
