using DG.Tweening;
using UnityEngine;

public class ScaleTweener : MonoBehaviour
{
    [Space]
    [SerializeField] private bool _isStart;
    [SerializeField] private Vector3 _scaleTo;
    [SerializeField, Range(0, 50f)] private float _duration = 1f;
    [SerializeField] private Ease _ease = Ease.InOutSine;
    [SerializeField, Range(-1, 50f)] private int _loops = -1;
    [SerializeField] private LoopType _loopType = LoopType.Yoyo;

    private Vector3 _originalScale;

    private Tween _tween;

    private void OnEnable()
    {
        _originalScale = transform.localScale;

        if (_isStart)
            Play();  
    }

    private void OnDisable() => _tween?.Kill();

    public void Play()
    {
        _tween?.Kill();

        transform.localScale = _originalScale;

        _tween = transform.DOScale(_scaleTo, _duration)
            .SetEase(_ease)
            .SetLoops(_loops, _loopType);
    }
}