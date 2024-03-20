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
        // if (Application.isMobilePlatform) 
        //     Container.BindInterfacesAndSelfTo<MobileInputService>().AsSingle();
        // else 
        //     Container.BindInterfacesAndSelfTo<DesktopInputService>().AsSingle();

//TODO: mobile input test
        Container.BindInterfacesAndSelfTo<MobileInputService>().AsSingle();
    }

    private void BindCursorService() 
        => Container.BindInterfacesAndSelfTo<CursorService>().AsSingle();

    private void BindPauseService()
        => Container.BindInterfacesAndSelfTo<PauseService>().AsSingle();
    
    private void BindLogService() 
        => Container.BindInterfacesTo<LogService>().AsSingle();  
}
