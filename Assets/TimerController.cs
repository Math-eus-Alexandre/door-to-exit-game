using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    // Verificar se o tempo entra no Top 5
    public bool IsNewRecord(int newTime)
    {
        for (int i = 0; i < 5; i++)
        {
            int saved = PlayerPrefs.GetInt("TopTimes_" + i, -1);

            if (saved == -1 || newTime < saved)
                return true;
        }
        return false;
    }

    // Registrar tempo e nome no Top 5
    public void RegisterRecord(int newTime, string playerName)
    {
        int[] times = new int[5];
        string[] names = new string[5];

        // Carregar dados antigos
        for (int i = 0; i < 5; i++)
        {
            times[i] = PlayerPrefs.GetInt("TopTimes_" + i, -1);
            names[i] = PlayerPrefs.GetString("TopNames_" + i, "---");
        }

        // Descobrir posição a inserir
        int pos = -1;
        for (int i = 0; i < 5; i++)
        {
            if (times[i] == -1 || newTime < times[i])
            {
                pos = i;
                break;
            }
        }

        if (pos == -1) return; // não entrou no top 5

        // Empurrar os registros para baixo
        for (int i = 4; i > pos; i--)
        {
            times[i] = times[i - 1];
            names[i] = names[i - 1];
        }

        // Inserir novo valor
        times[pos] = newTime;
        names[pos] = playerName;

        // Salvar PlayerPrefs
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("TopTimes_" + i, times[i]);
            PlayerPrefs.SetString("TopNames_" + i, names[i]);
        }

        PlayerPrefs.Save();
    }

    public void FinalizarTempo()
    {
        isRunning = false;

        int tempoFinal = Mathf.FloorToInt(currentTime);

        // Se for um recorde, pedir nome
        if (IsNewRecord(tempoFinal))
        {
            NameInputUI.Instance.Show(tempoFinal);
        }
        else
        {
            SceneManager.LoadScene("Top5");
        }
    }
}
