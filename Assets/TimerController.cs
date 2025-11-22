using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public static TimerController Instance;

    public TextMeshProUGUI timerText;
    public float currentTime = 0f;
    public bool isRunning = true;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime += Time.deltaTime;
        timerText.text = FormatTime(currentTime);
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public string FormatTime(float time)
    {
        int t = Mathf.FloorToInt(time);
        int min = t / 60;
        int sec = t % 60;

        return min.ToString("00") + ":" + sec.ToString("00");
    }
}