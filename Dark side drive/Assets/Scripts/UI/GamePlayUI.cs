using UnityEngine;
using System;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private Button pauseButton;

    public event Action IsPauseClicked;

    private void Awake()
    {
        pauseButton.onClick.AddListener(OnPause);
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnPause()
    {
        IsPauseClicked?.Invoke();
    }
}

