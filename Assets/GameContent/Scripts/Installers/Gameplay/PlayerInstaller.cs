using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _playerConfig;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
    }
}