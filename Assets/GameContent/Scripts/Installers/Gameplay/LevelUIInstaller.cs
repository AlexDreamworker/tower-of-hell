using UnityEngine;
using Zenject;

public class LevelUIInstaller : MonoInstaller
{
    [Space]
    [SerializeField] private MobileInput _mobileInputPrefab;

    [Space]
    [SerializeField] private HUD _hud;
    [SerializeField] private StartPanel _startPanel;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private DefeatPanel _defeatPanel;

    public override void InstallBindings()
    { 
        BindHUD();
        BindStartPanel();
        BindPausePanel();
        BindDefeatPanel();
        BindMobileInputView();
    }

    private void BindHUD()
        => Container.BindInterfacesAndSelfTo<HUD>().FromInstance(_hud).AsSingle();

    private void BindStartPanel()
        => Container.BindInterfacesAndSelfTo<StartPanel>().FromInstance(_startPanel).AsSingle();
    
    private void BindPausePanel()
        => Container.BindInterfacesAndSelfTo<PausePanel>().FromInstance(_pausePanel).AsSingle();

    private void BindDefeatPanel()
        => Container.BindInterfacesAndSelfTo<DefeatPanel>().FromInstance(_defeatPanel).AsSingle();

    private void BindMobileInputView() 
    {
        if (Application.isMobilePlatform)
            Container.InstantiatePrefabForComponent<MobileInput>(_mobileInputPrefab);

//TODO: mobile input test
        //Container.InstantiatePrefabForComponent<MobileInput>(_mobileInputPrefab);
    }
}