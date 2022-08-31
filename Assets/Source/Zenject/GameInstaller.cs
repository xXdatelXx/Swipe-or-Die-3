using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CharacterTeleport _characterTeleport;
    [SerializeField] private MazeFactory _mazeFactory;
    [SerializeField] private Tickables _tickable;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CharacterInput>().FromNew().AsSingle();
        Container.BindInstance(new LevelCreator(_mazeFactory, new Score(), _characterTeleport));
        Container.BindInterfacesAndSelfTo<Tickables>().FromInstance(_tickable).AsSingle();
    }
}
