using UnityEngine;

public class PreGameState : BaseGameState
{
    public PreGameState(Car car, IGameStateSwitcher gameStateSwitcher) : base(car, gameStateSwitcher)
    {

    }

    public override void StartGameState()
    {
        if (_car.TryGetComponent(out SplineMoveController splineMoveController))
        {
            splineMoveController.SetStartSettngs();
            splineMoveController.enabled = true;
            _car.RestoreHeals();
            _gameStateSwitcher.SwitchState<GamePlayState>();
        }
        else
        {
            Debug.LogError("SplineMoveController is not attached!");
        }
    }

    public override void StopGameState()
    {
        
    }
}
