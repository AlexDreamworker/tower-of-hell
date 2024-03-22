using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartPanel : BasePanel
{
    [SerializeField] private Button _buttonStart;

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
    }

    //TODO: Move animation in Tweener?
    private void Start() => Context.transform.DOScale(Vector3.one, AnimationDuration);

    private void OnDisable() => _buttonStart.RemoveListener(StartPressed);

    private void StartPressed() => _mediator.StartLevel();
}