using Zenject;

public class AdsInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.BindInterfacesAndSelfTo<GamePushAdsService>().AsSingle();
	}
}
