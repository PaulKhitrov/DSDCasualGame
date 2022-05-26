using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateManager : MonoBehaviour, IGameStateSwitcher
{
    [SerializeField] private Car _car;

    private BaseGameState _currentState;
    private List<BaseGameState> _allGameStatesList;

    private void Awake()
    {
        _allGameStatesList = new List<BaseGameState>()
        {
            new PreGameState(_car, this),
            new GamePlayState(_car, this),
            new PauseGameState(_car, this),
            new GameOverState(_car, this)
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