using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartPanel : MonoBehaviour
{
    [Space]
    [SerializeField] private GameObject _context;

    [Space]
    [SerializeField] private Button _buttonStart;

    //TODO: Duplicate code!
    [SerializeField, Range(0, 3f)] private float _normalScale = 1f;
    [SerializeField, Range(0, 3f)] private float _animationScale = 1.1f;
    [SerializeField, Range(0, 5f)] private float _animationDuration = 0.5f;

    private Level _level;

    private Tween _animationSequence;

    [Inject]
    private void Construct(Level level) 
        => _level = level;

    private void OnEnable()
    {
        _context.transform.localScale = Vector3.zero;
        _context.SetActive(true);

        _buttonStart.onClick.AddListener(StartCallback);

        TweenAnimation();
        _animationSequence.Play();
    }

    //TODO: Magic number!
    private void Start() 
        => _context.transform.DOScale(Vector3.one, 1f);

    private void OnDisable()
        => _buttonStart.onClick.RemoveListener(StartCallback);

    private void StartCallback()
    {
        _level.Start();
        _animationSequence.Pause();
        _context.SetActive(false);
    }

    //TODO: Move to button?
    private void TweenAnimation() 
    {
        _animationSequence = DOTween.Sequence()
            .Append(_buttonStart.gameObject.transform.DOScale(_animationScale, _animationDuration))
            .SetEase(Ease.InSine)
            .Append(_buttonStart.gameObject.transform.DOScale(_normalScale, _animationDuration))
            .SetEase(Ease.OutSine)
            .SetUpdate(UpdateType.Normal, true)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
