using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CursorHandler>().AsSingle();

        Container.BindInterfacesAndSelfTo<PauseHandler>().AsSingle();
    }
}
