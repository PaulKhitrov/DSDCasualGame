using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : BaseGameState
{
    private GameOverUI _gameOverUI = Object.FindObjectOfType<GameOverUI>();

    public GameOverState(Car car, IGameStateSwitcher gameStateSwitcher) : base(car, gameStateSwitcher)
    {

    }

    public override void StartGameState()
    {
        _gameOverUI.IsRestartClicked += RestartClick;
        _gameOverUI.IsQuitClicked += QuitClick;
        _gameOverUI.Show();
        ProjectContext.Instance.PauseManager.SetPause(true);
    }

    public override void StopGameState()
    {
        _gameOverUI.IsRestartClicked -= RestartClick;
        _gameOverUI.IsQuitClicked -= QuitClick;
        _gameOverUI.Hide();
    }

    private void RestartClick()
    {
        _gameStateSwitcher.SwitchState<PreGameState>();
    }

    private void QuitClick()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
