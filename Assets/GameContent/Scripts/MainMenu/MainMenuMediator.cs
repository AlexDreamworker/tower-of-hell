using Zenject;

public class MainMenuMediator
{
	private MainMenu _menu;
	private LevelSelectionPanel _selectionPanel; //???
	
	[Inject]
	private void Construct(MainMenu menu, LevelSelectionPanel selectionPanel) 
	{
		_menu = menu;
		_selectionPanel = selectionPanel;
	}
	
	public void LevelSelected(SceneID sceneID) => _menu.LevelSelected(sceneID);
}
