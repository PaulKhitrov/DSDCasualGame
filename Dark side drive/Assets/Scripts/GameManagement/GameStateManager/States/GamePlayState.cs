using UnityEngine;

public class GamePlayState : BaseGameState
{
    private GamePlayUI _gamePlayUI = Object.FindObjectOfType<GamePlayUI>();

    public GamePlayState(Car car, IGameStateSwitcher gameStateSwitcher) : base(car, gameStateSwitcher)
    {

    }

    public override void StartGameState()
    {
        _car.IsCarBumped += CarBump;
        _car.IsFinish += LevelComplete;
        _gamePlayUI.IsPauseClicked += OnPause;
        _gamePlayUI.Show();
    }

    public override void StopGameState()
    {
        _car.IsCarBumped -= CarBump;
        _car.IsFinish -= LevelComplete;
        _gamePlayUI.IsPauseClicked -= OnPause;
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

    private void LevelComplete()
    {
        Debug.Log("LEVEL COMPLETE!"); //реализовать еще одно состояние или просто выплюпнуть канвасину с кнопками? хм, вопрос.....
    }
}
