using System;
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
        BingCharacter();
    }

    private void BindCharacterConfig()
        => Container.Bind<CharacterConfig>().FromInstance(_config).AsSingle();

    private void BindCharacterCamera()
        => Container.Bind<CharacterCamera>().FromInstance(_camera).AsSingle();

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
}