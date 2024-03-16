using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLevel();
        BindTriggersReceiver();
    }

    private void BindLevel()
        => Container.BindInterfacesAndSelfTo<Level>().AsSingle();

    private void BindTriggersReceiver() 
        => Container.BindInterfacesAndSelfTo<DetectorReceiver>().AsSingle();
}