using Zenject;

public class MainMenuInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		BindMainMenu();
		BindMainMenuMediator();
	}

	private void BindMainMenu()
		=> Container.BindInterfacesAndSelfTo<MainMenu>().AsSingle();
		
	private void BindMainMenuMediator()
		=> Container.BindInterfacesAndSelfTo<MainMenuMediator>().AsSingle();
}
