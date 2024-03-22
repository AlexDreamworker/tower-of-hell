using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PausePanel : BasePanel
{
	[SerializeField] private Button _buttonContinue;
	[SerializeField] private Button _buttonExit;
	//[SerializeField] private Text _textLevelInfo;

	private LevelMediator _mediator;

	[Inject]
	private void Construct(LevelMediator mediator) 
		=> _mediator = mediator;

	private void OnEnable() 
	{
		_buttonContinue.AddListener(ContinuePressed);
		_buttonExit.AddListener(ExitPressed);
	}

	private void OnDisable() 
	{
		_buttonContinue.RemoveListener(ContinuePressed);
		_buttonExit.RemoveListener(ExitPressed);
	}
	
	//public void SetLevelInfo(int level) => _textLevelInfo.text = level.ToString();

	private void ContinuePressed() => _mediator.ContinueLevel();
	private void ExitPressed() => _mediator.GoToMainMenu();
}