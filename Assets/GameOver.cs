using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;

    [Header("UI")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalTimeText;

    [Header("Timer")]
    public float timer;
    public bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (isGameOver) return;

        // Atualiza cronômetro
        timer += Time.deltaTime;
    }

    public void TriggerGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        TimerController.Instance.StopTimer();

        int totalSeconds = Mathf.FloorToInt(TimerController.Instance.currentTime);

        AddRecord.RegisterTime(totalSeconds);

        finalTimeText.text = "Tempo: " + TimerController.Instance.FormatTime(totalSeconds);

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    // Reinicia o jogo
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    private string FormatTime(int time)
    {
        int min = time / 60;
        int sec = time % 60;
        return min.ToString("00") + ":" + sec.ToString("00");
    }
}
