using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private CharacterCamera _camera;
    [SerializeField] private Character _prefab;
    [SerializeField] private Transform _spawnPoint;
    
    public override void InstallBindings() 
    {
        BindCharacterConfig();
        BindCharacterCamera();
        BingMovementStateMachine();
        BindMovementStateMachineData();
        BingCharacter();
        BindStates();
        BindMovementStateMachineProvider();
    }

    private void BindCharacterConfig()
        => Container.Bind<CharacterConfig>().FromInstance(_config).AsSingle();

    private void BindCharacterCamera()
        => Container.Bind<CharacterCamera>().FromInstance(_camera).AsSingle();

    private void BingMovementStateMachine()
        => Container.BindInterfacesAndSelfTo<MovementStateMachine>().AsSingle();

    private void BindMovementStateMachineData()
        => Container.Bind<MovementStateMachineData>().AsSingle();

    private void BingCharacter()
    {
        Character player = Container.InstantiatePrefabForComponent<Character>(
            _prefab, 
            _spawnPoint.position, 
            Quaternion.identity, 
            null
        );

        Container.BindInterfacesAndSelfTo<Character>().FromInstance(player).AsSingle();
    }

    private void BindStates() 
    {
        Container.BindInterfacesAndSelfTo<IdleState>().AsSingle();
        Container.BindInterfacesAndSelfTo<WalkingState>().AsSingle();
        Container.BindInterfacesAndSelfTo<RunningState>().AsSingle();
        Container.BindInterfacesAndSelfTo<FallingState>().AsSingle();
        Container.BindInterfacesAndSelfTo<JumpingState>().AsSingle();
        Container.BindInterfacesAndSelfTo<CrouchingState>().AsSingle();
        Container.BindInterfacesAndSelfTo<DuckingState>().AsSingle();
        Container.BindInterfacesAndSelfTo<DashState>().AsSingle();
    }

    private void BindMovementStateMachineProvider() 
    {
        Container.Bind<MovementStateMachineProvider>().AsSingle().NonLazy();
    }
}