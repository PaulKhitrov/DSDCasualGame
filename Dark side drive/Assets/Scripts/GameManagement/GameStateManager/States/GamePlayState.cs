public class GamePlayState : BaseGameState
{
    private GamePlayUI _gamePlayUI;
    private FinishLine _finishLine;
    private SplineMoveController _splineMoveController;
    private PlayerTouchInput _playerTouchInput;

    public GamePlayState(IGameStateSwitcher gameStateSwitcher, Car car, FinishLine finishLine, GamePlayUI gamePlayUI) : base(gameStateSwitcher, car)
    {
        _gamePlayUI = gamePlayUI;
        _finishLine = finishLine;
        _playerTouchInput = new PlayerTouchInput();
    }

    public override void StartGameState()
    {
        _gamePlayUI.Show();
        _splineMoveController = _car.GetComponent<SplineMoveController>();
        _playerTouchInput.Enable();
        _car.IsCarBumped += CarBump;
        _gamePlayUI.IsPauseClicked += OnPause;
        _finishLine.IsCrossFinishLine += OnFinished;
        _playerTouchInput.ToLeft += StrafeLeft;
        _playerTouchInput.ToRight += StrafeRight;
    }

    public override void StopGameState()
    {
        _car.IsCarBumped -= CarBump;
        _gamePlayUI.IsPauseClicked -= OnPause;
        _finishLine.IsCrossFinishLine -= OnFinished;
        _playerTouchInput.ToLeft -= StrafeLeft;
        _playerTouchInput.ToRight -= StrafeRight;
        _playerTouchInput.Disable();
    }

    private void StrafeRight()
    {
        _splineMoveController.StrafeRight();
    }

    private void StrafeLeft()
    {
        _splineMoveController.StrafeLeft();
    }

    private void OnPause()
    {
        _gamePlayUI.Hide();
        _gameStateSwitcher.SwitchState<PauseGameState>();
    }

    private void CarBump()
    {
        if (_car.Heals <= 0)
        {
            _gamePlayUI.Hide();
            _gameStateSwitcher.SwitchState<GameOverState>();
        }
    }

    private void OnFinished()
    {
        _gamePlayUI.Hide();
        _gameStateSwitcher.SwitchState<LevelCompleteState>();
    }
}