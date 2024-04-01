using GamePush;
using Zenject;

public class MainMenu : IInitializable
{
	private SceneLoadMediator _loader;
	private Curtain _curtain;
	
	private SceneID _sceneToLoad;
	
	private MainMenu(SceneLoadMediator loader, Curtain curtain)
	{
		_loader = loader;
		_curtain = curtain;
	}
	
	public void Initialize()
	{
		_curtain.Hide();

		GP_Ads.ShowFullscreen(); //TODO: Move GP logic to GP Service
	}
	
	public void LevelSelected(SceneID sceneID) 
	{
		_curtain.Completed += OnCurtainCompleted;
		_curtain.Show();
		_sceneToLoad = sceneID;
	}
	
	private void OnCurtainCompleted() 
	{
		_curtain.Completed -= OnCurtainCompleted;
		
		LoadLevel(_sceneToLoad);
	}
	
	private void LoadLevel(SceneID sceneID) 
		=> _loader.GoToLevel(sceneID, new LevelLoadingData((int)sceneID));
}
