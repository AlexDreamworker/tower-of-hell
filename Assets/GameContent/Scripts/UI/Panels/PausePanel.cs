using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PausePanel : BasePanel
{
    [SerializeField] private Button _buttonContinue;

    private UIMediator _mediator;

    [Inject]
    private void Construct(UIMediator mediator) 
        => _mediator = mediator;

    private void OnEnable() => _buttonContinue.onClick.AddListener(ContinuePressed);

    private void OnDisable() => _buttonContinue.onClick.RemoveListener(ContinuePressed);

    private void ContinuePressed() => _mediator.ContinueLevel();
}
