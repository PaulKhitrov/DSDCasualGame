using UnityEngine;

public class LevelCompleteState : BaseGameState
{
    private PauseManager PauseManager => ProjectContext.Instance.PauseManager;

    public LevelCompleteState(IGameStateSwitcher gameStateSwitcher, Car car) : base(gameStateSwitcher, car)
    {

    }

    public override void StartGameState()
    {
        Debug.Log("LEVEL COMPLETE START STATE");
        PauseManager.SetPause(true);
    }

    public override void StopGameState()
    {

    }
}