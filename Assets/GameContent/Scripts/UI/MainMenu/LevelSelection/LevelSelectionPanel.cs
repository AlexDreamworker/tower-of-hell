using UnityEngine;
using Zenject;

public class LevelSelectionPanel : MonoBehaviour
{
	[SerializeField] private LevelSelectionButton[] _levelSelectionButtons;
	
	private MainMenuMediator _mediator;
	private IProgressService _progress;
	
	[Inject]
	private void Construct(MainMenuMediator mediator, IProgressService progress) 
	{
		_mediator = mediator;
		_progress = progress;
	}
		
	private void OnEnable()
	{
		foreach (var levelSelectionButton in _levelSelectionButtons)
			levelSelectionButton.Click += OnLevelSelected;
	}

	private void Start() => UpdateLevels();

	private void OnDisable()
	{
		foreach (var levelSelectionButton in _levelSelectionButtons)
			levelSelectionButton.Click -= OnLevelSelected;
	}
	
	private void UpdateLevels() 
	{
		int currentLevel = _progress.Load(StorageKeys.Levels);
		currentLevel++;

		for (int i = 0; i < _levelSelectionButtons.Length; i++)
		{
			bool result = i < currentLevel;
			_levelSelectionButtons[i].SetInteractable(result);
		}
	}
	
	private void OnLevelSelected(SceneID sceneID) => _mediator.LevelSelected(sceneID);
}