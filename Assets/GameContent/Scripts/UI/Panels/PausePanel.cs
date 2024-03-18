using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PausePanel : MonoBehaviour
{
    [Space]
    [SerializeField] private Context _context;
    [SerializeField] private Button _buttonContinue;

    private IPauseService _pauseService;

    [Inject]
    private void Construct(IPauseService pauseService) 
        => _pauseService = pauseService;

    private void OnEnable()
    {
        _pauseService.PauseChanged += OnPauseChanged;
        _buttonContinue.onClick.AddListener(ContinueCallback);
    }

    private void OnDisable()
    {
        _pauseService.PauseChanged -= OnPauseChanged;
        _buttonContinue.onClick.RemoveListener(ContinueCallback);
    }

    private void OnPauseChanged(bool isPause)
        => _context.SetActive(isPause);

    private void ContinueCallback() 
        => _pauseService.SetPause(false);
}
