using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameInputUI : MonoBehaviour
{
    public static NameInputUI Instance;

    public GameObject panel;        // Painel que aparece
    public TMP_InputField inputName;

    private int pendingTime;

    private void Awake()
    {
        Instance = this;
    }

    public void Show(int timeToSave)
    {
        pendingTime = timeToSave;
        panel.SetActive(true);
        inputName.text = "";
    }

    public void Confirmar()
    {
        string playerName = inputName.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
        }

        TimerController.Instance.RegisterRecord(pendingTime, playerName);

        SceneManager.LoadScene("Top5");
    }
}