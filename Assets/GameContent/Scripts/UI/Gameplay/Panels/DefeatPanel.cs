using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DefeatPanel : BasePanel
{
    [SerializeField] private Button _buttonContinue;

    private LevelMediator _mediator;

    [Inject]
    private void Construct(LevelMediator mediator) 
        => _mediator = mediator;

    private void Start() => Hide();

    private void OnEnable() => _buttonContinue.AddListener(RestartPressed);

    private void OnDisable() => _buttonContinue.RemoveListener(RestartPressed);

    private void RestartPressed() => _mediator.RestartLevel();
}
