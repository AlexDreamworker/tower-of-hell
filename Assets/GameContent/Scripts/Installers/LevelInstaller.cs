using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Transform _characterSpawnPoint;
    [SerializeField] private Curtain _curtain; //TODO: move this?

    public override void InstallBindings()
    {
        BindCheckpointsHandler();
        BindLevel();
        BindTriggersReceiver();
        BindCurtain();
    }

    private void BindCheckpointsHandler()
        => Container.BindInterfacesAndSelfTo<CheckpointsHandler>()
            .AsSingle()
            .WithArguments(_characterSpawnPoint.transform.position);

    private void BindLevel()
        => Container.BindInterfacesAndSelfTo<Level>().AsSingle();

    private void BindTriggersReceiver() 
        => Container.BindInterfacesAndSelfTo<DetectorReceiver>().AsSingle();

    //TODO: move this?
    private void BindCurtain() 
        => Container.Bind<Curtain>().FromInstance(_curtain).AsSingle();
}