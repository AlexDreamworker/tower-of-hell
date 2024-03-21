using System;

public class SceneLoader : ISimpleSceneLoader, ILevelLoader
{
	private ZenjectSceneLoaderWrapper _zenjectSceneLoader;

	public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader)
		=> _zenjectSceneLoader = zenjectSceneLoader;

	public void Load(SceneID sceneID)
	{
		if (sceneID != SceneID.MainMenu)
			throw new ArgumentException($"{sceneID} cannot be started without configuraton, use ILevelLoader");

		_zenjectSceneLoader.Load(null, (int)sceneID);
	}

	public void Load(SceneID sceneID, LevelLoadingData levelLoadingData)
	{
		if (sceneID == SceneID.MainMenu)
			throw new ArgumentException($"{sceneID} cannot be started with configuraton, use ISimpleSceneLoader");
			
		_zenjectSceneLoader.Load(container =>
		{
			container.BindInstance(levelLoadingData);
		}, (int)sceneID);
	}
}
