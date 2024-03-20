using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [Space]
    [SerializeField] private MobileInput _mobileInputPrefab;

    [Space]
    [SerializeField] private Curtain _curtain;
    [SerializeField] private HUD _hud;
    [SerializeField] private StartPanel _startPanel;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private DefeatPanel _defeatPanel;

    public override void InstallBindings()
    { 
        BindCurtain();
        BindHUD();
        BindStartPanel();
        BindPausePanel();
        BindDefeatPanel();
        BindUIMediator();
        BindMobileInputView();
    }

    private void BindCurtain()
        => Container.Bind<Curtain>().FromInstance(_curtain).AsSingle();

    private void BindHUD()
        => Container.BindInterfacesAndSelfTo<HUD>().FromInstance(_hud).AsSingle();

    private void BindStartPanel()
        => Container.BindInterfacesAndSelfTo<StartPanel>().FromInstance(_startPanel).AsSingle();
    
    private void BindPausePanel()
        => Container.BindInterfacesAndSelfTo<PausePanel>().FromInstance(_pausePanel).AsSingle();

    private void BindDefeatPanel()
        => Container.BindInterfacesAndSelfTo<DefeatPanel>().FromInstance(_defeatPanel).AsSingle();

    private void BindUIMediator() 
        => Container.BindInterfacesAndSelfTo<UIMediator>().AsSingle();

    private void BindMobileInputView() 
    {
        // if (Application.isMobilePlatform)
            // Container.InstantiatePrefabForComponent<MobileInput>(_mobileInputPrefab);

//TODO: mobile input test
        Container.InstantiatePrefabForComponent<MobileInput>(_mobileInputPrefab);
    }
}