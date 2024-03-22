using UnityEngine;
using Zenject;

public class MainMenuUIInstaller : MonoInstaller
{
	[SerializeField] private LevelSelectionPanel _levelSelectionPanel; 
	
	public override void InstallBindings()
		=> BindLevelSelectionPanel();
	
	private void BindLevelSelectionPanel()
        => Container.BindInterfacesAndSelfTo<LevelSelectionPanel>().FromInstance(_levelSelectionPanel).AsSingle();
}
