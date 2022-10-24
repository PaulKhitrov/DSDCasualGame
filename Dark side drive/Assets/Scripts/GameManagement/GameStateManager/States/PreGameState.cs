public class PreGameState : BaseGameState
{
    private SplineMoveController _splineMoveController;

    public PreGameState(IGameStateSwitcher gameStateSwitcher, Car car) : base(gameStateSwitcher, car)
    {
        
    }

    public override void StartGameState()
    {
        _splineMoveController = _car.GetComponent<SplineMoveController>();
        _splineMoveController.SetStartSettngs();
        _splineMoveController.enabled = true;
        _car.RestoreHeals();
        _gameStateSwitcher.SwitchState<GamePlayState>();
    }

    public override void StopGameState()
    {

    }
}