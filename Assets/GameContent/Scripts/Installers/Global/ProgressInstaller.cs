using Zenject;

public class ProgressInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LevelProgressService>().AsSingle();
    }
}
