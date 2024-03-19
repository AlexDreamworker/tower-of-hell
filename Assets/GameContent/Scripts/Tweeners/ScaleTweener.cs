using System;
using DG.Tweening;
using UnityEngine;

public class ScaleTweener : MonoBehaviour
{
    public event Action Complete;

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

    public void Play(bool isHideAfterComplete = false)
    {
        _tween?.Kill();

        transform.localScale = _originalScale;

        DoScale(_scaleTo, _duration, _ease, _loops, _loopType, isHideAfterComplete);
    }

    public void Play(
        Vector3 scaleTo, 
        float duration = 1f, 
        Ease ease = Ease.InOutSine, 
        int loops = -1, 
        LoopType loopType = LoopType.Yoyo,
        bool isHideAfterComplete = false) 
    {
        _tween?.Kill();

        transform.localScale = _originalScale;

        DoScale(scaleTo, duration, ease, loops, loopType, isHideAfterComplete);
    }

    public void Play(
        Vector3 originalScale, 
        Vector3 scaleTo, 
        float duration = 1f, 
        Ease ease = Ease.InOutSine, 
        int loops = -1, 
        LoopType loopType = LoopType.Yoyo,
        bool isHideAfterComplete = false) 
    {
        _tween?.Kill();

        transform.localScale = originalScale;

        DoScale(scaleTo, duration, ease, loops, loopType, isHideAfterComplete);
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void DoScale(Vector3 scaleTo, float duration, Ease ease, int loops, LoopType loopType, bool isHideOnComplete) 
    {
        _tween = transform.DOScale(scaleTo, duration)
            .SetEase(ease)
            .SetLoops(loops, loopType)
            .OnComplete(() => 
            {
                if (isHideOnComplete)
                    Hide();

                Complete?.Invoke();
            });
    }
}