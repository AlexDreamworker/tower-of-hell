using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private MobileInput _mobileInputPrefab;

    public override void InstallBindings()
    {
        BindInputService();
        BindCursorService();
        BindPauseService();
        BindLogService();
        BindMobileInputView();
    }

    //TODO: mobile input test
    private void BindInputService() 
    {
        if (Application.isMobilePlatform) 
            Container.BindInterfacesAndSelfTo<MobileInputService>().AsSingle();
        else 
            Container.BindInterfacesAndSelfTo<DesktopInputService>().AsSingle();
    }

    private void BindCursorService() 
        => Container.BindInterfacesAndSelfTo<CursorService>().AsSingle();

    private void BindPauseService()
        => Container.BindInterfacesAndSelfTo<PauseService>().AsSingle();
    
    private void BindLogService() 
        => Container.BindInterfacesTo<LogService>().AsSingle();

    //TODO: mobile input test
    private void BindMobileInputView() 
    {
        if (Application.isMobilePlatform)
            Container.InstantiatePrefabForComponent<MobileInput>(_mobileInputPrefab);
    }
}
