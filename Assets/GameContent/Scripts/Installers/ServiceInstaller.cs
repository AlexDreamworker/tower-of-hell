using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInputService();
        BindCursorService();
        BindPauseService();
        BindLogService();
    }

    private void BindInputService() 
    {
        //TODO: Add mobile input
        Container.BindInterfacesAndSelfTo<DesktopInputService>().AsSingle();
    }

    private void BindCursorService() 
        => Container.BindInterfacesAndSelfTo<CursorService>().AsSingle();

    private void BindPauseService()
        => Container.BindInterfacesAndSelfTo<PauseService>().AsSingle();
    
    private void BindLogService() 
        => Container.BindInterfacesTo<LogService>().AsSingle();
}
