using Source;
using Source.Model.Timer;
using SwipeOrDie.Factory;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Input;
using SwipeOrDie.View;
using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CharacterTeleport _characterTeleport;
    [SerializeField] private MazeFactory _mazeFactory;
    [SerializeField] private LoseView _loseView;
    [SerializeField] private TimerView _gameTimerView;

    public override void InstallBindings()
    {
        var pause = new GamePause();
        var lose = new Losing(_loseView, pause);
        var gameTimer = new GameTimer(lose, _gameTimerView);
        gameTimer.Play();

        Container.BindInterfacesAndSelfTo<CharacterInput>().FromNew().AsSingle();
        Container.BindInstance(new LevelCreator(_mazeFactory, new Score(), _characterTeleport, gameTimer));
        Container.BindInstance(lose);
        Container.BindInstance(pause);
    }
}