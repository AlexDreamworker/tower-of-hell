using UnityEngine;
using Zenject;

public class LevelSelectionPanel : MonoBehaviour
{
	[SerializeField] private LevelSelectionButton[] _levelSelectionButtons;
	
	private MainMenuMediator _mediator;
	
	[Inject]
	private void Construct(MainMenuMediator mediator)
		=> _mediator = mediator;
		
	private void OnEnable()
	{
		foreach (var levelSelectionButton in _levelSelectionButtons)
			levelSelectionButton.Click += OnLevelSelected;
	}

	private void OnDisable()
	{
		foreach (var levelSelectionButton in _levelSelectionButtons)
			levelSelectionButton.Click -= OnLevelSelected;
	}
	
	private void OnLevelSelected(SceneID sceneID) => _mediator.LevelSelected(sceneID);
}