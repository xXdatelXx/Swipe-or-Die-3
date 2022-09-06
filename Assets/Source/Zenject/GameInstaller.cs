using SwipeOrDie.Factory;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Input;
using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private readonly CharacterTeleport _characterTeleport;
    [SerializeField] private readonly MazeFactory _mazeFactory;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CharacterInput>().FromNew().AsSingle();
        Container.BindInstance(new LevelCreator(_mazeFactory, new Score(), _characterTeleport));
    }
}
