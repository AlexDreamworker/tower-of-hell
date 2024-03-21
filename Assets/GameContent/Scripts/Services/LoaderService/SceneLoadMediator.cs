using Zenject;

public class SceneLoadMediator
{
	private ISimpleSceneLoader _simpleSceneLoader;
	private ILevelLoader _levelLoader;

	[Inject]
	private void Construct(ISimpleSceneLoader simpleSceneLoader, ILevelLoader levelLoader)
	{
		_simpleSceneLoader = simpleSceneLoader;
		_levelLoader = levelLoader;
	}

	public void GoToMainMenu()
        => _simpleSceneLoader.Load(SceneID.MainMenu);

	public void GoToLevel(SceneID sceneID, LevelLoadingData levelLoadingData)
		=> _levelLoader.Load(sceneID, levelLoadingData);
}