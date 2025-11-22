using UnityEngine;

public static class AddRecord
{
    public static void RegisterTime(int newTime)
    {
        int[] times = new int[5];

        // Load
        for (int i = 0; i < 5; i++)
            times[i] = PlayerPrefs.GetInt("TopTimes_" + i, -1);

        // Add novo
        for (int i = 0; i < 5; i++)
        {
            if (times[i] == -1 || newTime < times[i])
            {
                for (int j = 4; j > i; j--)
                    times[j] = times[j - 1];

                times[i] = newTime;
                break;
            }
        }

        // Save
        for (int i = 0; i < 5; i++)
            PlayerPrefs.SetInt("TopTimes_" + i, times[i]);

        PlayerPrefs.Save();
    }
}