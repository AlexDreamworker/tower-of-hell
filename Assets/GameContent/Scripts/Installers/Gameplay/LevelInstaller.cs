using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [Space]
    [SerializeField] private Transform _characterSpawnPoint;

    public override void InstallBindings()
    {
        BindCheckpointsHandler();
        BindLevel();
        BindTriggersReceiver();
    }

    private void BindCheckpointsHandler()
        => Container.BindInterfacesAndSelfTo<CheckpointsHandler>()
            .AsSingle()
            .WithArguments(_characterSpawnPoint.transform.position);

    private void BindLevel()
        => Container.BindInterfacesAndSelfTo<Level>().AsSingle();

    private void BindTriggersReceiver() 
        => Container.BindInterfacesAndSelfTo<DetectorReceiver>().AsSingle();
}