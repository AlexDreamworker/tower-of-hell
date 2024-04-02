using Zenject;

public class MainMenu : IInitializable
{
	private SceneLoadMediator _loader;
	private Curtain _curtain;
	private IAdsService _ads;
	
	private SceneID _sceneToLoad;
	
	private MainMenu(SceneLoadMediator loader, Curtain curtain, IAdsService ads)
	{
		_loader = loader;
		_curtain = curtain;
		_ads = ads;
	}
	
	public void Initialize()
	{
		_curtain.Hide();
		_ads.ShowFullScreen();
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
