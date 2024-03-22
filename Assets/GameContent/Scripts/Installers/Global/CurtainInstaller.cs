using UnityEngine;
using Zenject;

public class CurtainInstaller : MonoInstaller
{
	[SerializeField] private Curtain _prefab;

	public override void InstallBindings() 
		=> BindCurtain();

	private void BindCurtain()
	{
		Curtain curtain = Container.InstantiatePrefabForComponent<Curtain>(_prefab);
		Container.BindInterfacesAndSelfTo<Curtain>().FromInstance(curtain).AsSingle();
	}
}
