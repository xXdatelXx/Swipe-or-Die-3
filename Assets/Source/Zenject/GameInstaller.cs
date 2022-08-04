using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(new PlayerInput() as IInput);
    }
}
