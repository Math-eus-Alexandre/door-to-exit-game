using UnityEngine;
using TMPro;

public class Top5Manager : MonoBehaviour
{
    public TextMeshProUGUI recordsText;

    void Start()
    {
        LoadTop5();
    }

    void LoadTop5()
    {
        string result = "";

        for (int i = 0; i < 5; i++)
        {
            int time = PlayerPrefs.GetInt("TopTimes_" + i, -1);
            string name = PlayerPrefs.GetString("TopNames_" + i, "---");

            if (time == -1)
            {
                result += (i + 1) + ". ---  -  --:--\n";
            }
            else
            {
                result += (i + 1) + ". " + name + "  -  " + FormatTime(time) + "\n";
            }
        }

        recordsText.text = result;
    }

    string FormatTime(int seconds)
    {
        int min = seconds / 60;
        int sec = seconds % 60;

        return min.ToString("00") + ":" + sec.ToString("00");
    }
}