using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartPanel : BasePanel
{
	[SerializeField] private Button _buttonStart;
	[SerializeField] private Button _buttonExit;
	[SerializeField] private Text _textLevelInfo;

	private const float AnimationDuration = 1f;

	private LevelMediator _mediator;

	[Inject]
	private void Construct(LevelMediator mediator) 
		=> _mediator = mediator;

	private void OnEnable()
	{
		Context.transform.localScale = Vector3.zero;
		Show();

		_buttonStart.AddListener(StartPressed);
		_buttonExit.AddListener(ExitPressed);
	}

	//TODO: Move animation in Tweener?
	private void Start() => Context.transform.DOScale(Vector3.one, AnimationDuration);

	private void OnDisable()
	{
		_buttonStart.RemoveListener(StartPressed);
		_buttonExit.RemoveListener(ExitPressed);
	}
	
	public void SetLevelInfo(int level) => _textLevelInfo.text = level.ToString();

	private void StartPressed() => _mediator.StartLevel();
	private void ExitPressed() => _mediator.GoToMainMenu();
}