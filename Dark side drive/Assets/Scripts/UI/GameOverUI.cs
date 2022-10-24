using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    public event Action IsQuitClicked;
    public event Action IsRestartClicked;

    private void Awake()
    {
        restartButton.onClick.AddListener(OnClickRestartButton);
        quitButton.onClick.AddListener(OnClickQuitButton);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnClickQuitButton()
    {
        IsQuitClicked?.Invoke();
    }

    private void OnClickRestartButton()
    {
        IsRestartClicked?.Invoke();
    }
}
