using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button StartGameButton;
    [SerializeField] private Button ExitButton;

    private void Awake()
    {
        StartGameButton.onClick.AddListener(StartGameClicked);
        ExitButton.onClick.AddListener(ExitClicked);
    }

    private void StartGameClicked()
    {
        SceneManager.LoadSceneAsync(1);
    }

    private void ExitClicked()
    {
        Application.Quit();
    }
}
