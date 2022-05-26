using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameState : BaseGameState
{
    private PauseUI _pauseUI = Object.FindObjectOfType<PauseUI>();

    private PauseManager PauseManager => ProjectContext.Instance.PauseManager;

    public PauseGameState(Car car, IGameStateSwitcher gameStateSwitcher) : base(car, gameStateSwitcher)
    {

    }

    public override void StartGameState()
    {
        PauseManager.SetPause(true);
        _pauseUI.Show();
        _pauseUI.IsContinueClicked += OnContinue;
        _pauseUI.IsRestartClicked += OnRestart;
        _pauseUI.IsQuitClicked += OnQuit;
    }

    public override void StopGameState()
    {
        _pauseUI.Hide();
        _pauseUI.IsContinueClicked -= OnContinue;
        _pauseUI.IsRestartClicked -= OnRestart;
        _pauseUI.IsQuitClicked -= OnQuit;
    }

    private void OnContinue()
    {
        PauseManager.SetPause(false);
        _gameStateSwitcher.SwitchState<GamePlayState>();
    }

    private void OnRestart()
    {
        _gameStateSwitcher.SwitchState<PreGameState>();
    }

    private void OnQuit()
    {
        SceneManager.LoadSceneAsync(0);
    }
}