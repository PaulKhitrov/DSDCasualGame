using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateManager : MonoBehaviour, IGameStateSwitcher
{
    [SerializeField] private Car _car;
    [SerializeField] private FinishLine _finishLine;
    [SerializeField] private PauseUI _pauseUI;
    [SerializeField] private GamePlayUI _gamePlayUI;
    [SerializeField] private GameOverUI _gameOverUI;

    private BaseGameState _currentState;
    private List<BaseGameState> _allGameStatesList;

    private void Awake()
    {
        _allGameStatesList = new List<BaseGameState>()
        {
            new PreGameState(this, _car),
            new GamePlayState(this, _car, _finishLine, _gamePlayUI),
            new PauseGameState(this, _car, _pauseUI),
            new GameOverState(this, _car, _gameOverUI),
            new LevelCompleteState(this, _car)
        };
    }

    private void Start()
    {
        _currentState = _allGameStatesList[0];
        _currentState.StartGameState();
    }

    public void SwitchState<T>() where T : BaseGameState
    {
        var nextState = _allGameStatesList.FirstOrDefault(state => state is T);
        _currentState.StopGameState();
        nextState.StartGameState();
        _currentState = nextState;
    }
}