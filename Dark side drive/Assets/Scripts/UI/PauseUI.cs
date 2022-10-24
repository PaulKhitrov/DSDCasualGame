using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    public event Action IsContinueClicked;
    public event Action IsRestartClicked;
    public event Action IsQuitClicked;

    private void Awake()
    {
        continueButton.onClick.AddListener(ContinueClicked);
        restartButton.onClick.AddListener(RestartClicked);
        quitButton.onClick.AddListener(QuitClicked);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ContinueClicked()
    {
        IsContinueClicked?.Invoke();
    }

    private void RestartClicked()
    {
        IsRestartClicked?.Invoke();
    }

    private void QuitClicked()
    {
        IsQuitClicked?.Invoke();
    }
}
