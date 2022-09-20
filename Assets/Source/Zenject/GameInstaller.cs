using Source;
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
    [SerializeField] private LoseView _gameTimerLoseView;
    [SerializeField] private TimerView _gameTimerView;

    public override void InstallBindings()
    {
        var gameTimer = new GameTimer(_gameTimerLoseView, _gameTimerView);
        gameTimer.Play();

        Container.BindInterfacesAndSelfTo<CharacterInput>().FromNew().AsSingle();
        Container.BindInstance(new LevelCreator(_mazeFactory, new Score(), _characterTeleport, gameTimer));
    }
}