using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameInputUI : MonoBehaviour
{
    public static NameInputUI Instance;

    public TMP_InputField nameField;
    private int pendingTime;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show(int time)
    {
        pendingTime = time;
        gameObject.SetActive(true);
    }

    public void Confirm()
    {
        string nome = nameField.text.Trim();
        if (nome == "") nome = "Jogador";

        TimerController.Instance.RegisterRecord(pendingTime, nome);

        SceneManager.LoadScene("Top5");
    }
}