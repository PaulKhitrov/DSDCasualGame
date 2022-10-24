using UnityEngine.SceneManagement;

public class GameOverState : BaseGameState
{
    private GameOverUI _gameOverUI;

    public GameOverState(IGameStateSwitcher gameStateSwitcher, Car car, GameOverUI gameOverUI) : base(gameStateSwitcher, car)
    {
        _gameOverUI = gameOverUI;
    }

    public override void StartGameState()
    {
        _gameOverUI.IsRestartClicked += OnRestart;
        _gameOverUI.IsQuitClicked += OnQuit;
        _gameOverUI.Show();
        ProjectContext.Instance.PauseManager.SetPause(true);
    }

    public override void StopGameState()
    {
        _gameOverUI.IsRestartClicked -= OnRestart;
        _gameOverUI.IsQuitClicked -= OnQuit;
        _gameOverUI.Hide();
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