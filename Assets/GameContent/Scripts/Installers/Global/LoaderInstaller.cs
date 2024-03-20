using Zenject;

public class LoaderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        Container.Bind<SceneLoadMediator>().AsSingle();
    }
}