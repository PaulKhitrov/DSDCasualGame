public abstract class BaseGameState
{
    protected readonly Car _car;
    protected readonly IGameStateSwitcher _gameStateSwitcher;

    protected BaseGameState(Car car, IGameStateSwitcher gamePlayStateSwitcher)
    {
        _car = car;
        _gameStateSwitcher = gamePlayStateSwitcher;
    }

    public abstract void StartGameState();
    public abstract void StopGameState();
}
