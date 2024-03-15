using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PausePanel : MonoBehaviour
{
    [Space]
    [SerializeField] private GameObject _context;

    [Space]
    [SerializeField] private Button _buttonContinue;

    //TODO: Duplicate code!
    [SerializeField, Range(0, 3f)] private float _normalScale = 1f;
    [SerializeField, Range(0, 3f)] private float _animationScale = 1.1f;
    [SerializeField, Range(0, 5f)] private float _animationDuration = 0.5f;

    private IPauseService _pauseService;

    private Tween _animationSequence;

    [Inject]
    private void Construct(IPauseService pauseService) 
    {
        _pauseService = pauseService;
    }

    private void OnEnable()
    {
        _pauseService.PauseChanged += OnPauseChanged;
        _buttonContinue.onClick.AddListener(ContinueCallback);

        TweenAnimation();
        
        _animationSequence.Pause();
    }

    private void OnDisable()
    {
        _pauseService.PauseChanged -= OnPauseChanged;
        _buttonContinue.onClick.RemoveListener(ContinueCallback);
    }

    private void OnPauseChanged(bool isPause)
    {
        if (isPause)
            _animationSequence.Play();
        else 
            _animationSequence.Pause();
        
        _context.SetActive(isPause);
    }

    private void ContinueCallback() 
        => _pauseService.SetPause(false);

    //TODO: Move to button?
    private void TweenAnimation() 
    {
        _animationSequence = DOTween.Sequence()
            .Append(_buttonContinue.gameObject.transform.DOScale(_animationScale, _animationDuration))
            .SetEase(Ease.InSine)
            .Append(_buttonContinue.gameObject.transform.DOScale(_normalScale, _animationDuration))
            .SetEase(Ease.OutSine)
            .SetUpdate(UpdateType.Normal, true)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
