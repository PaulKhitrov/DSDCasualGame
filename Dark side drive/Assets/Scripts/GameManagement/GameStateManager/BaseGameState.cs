public abstract class BaseGameState
{
    protected readonly Car _car;
    protected readonly IGameStateSwitcher _gameStateSwitcher;

    protected BaseGameState(IGameStateSwitcher gamePlayStateSwitcher, Car car)
    {
        _gameStateSwitcher = gamePlayStateSwitcher;
        _car = car;
    }

    public abstract void StartGameState();
    public abstract void StopGameState();
}
