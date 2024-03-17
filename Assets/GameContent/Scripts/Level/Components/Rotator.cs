using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Space]
    [SerializeField] private Vector3 _rotation;
    [SerializeField, Range(0, 50f)] private float _duration = 5f;

    [Space]
    [SerializeField] private RotateMode _rotateMode = RotateMode.FastBeyond360;
    [SerializeField, Range(-1, 10)] private int _loops = -1;
    [SerializeField] private LoopType _loopType = LoopType.Yoyo;
    [SerializeField] private Ease _ease = Ease.Linear;

    private void Start() => Rotate();

    private void Rotate() 
    {
        transform.DORotate(_rotation, _duration, _rotateMode)
            .SetLoops(_loops, _loopType)
            .SetRelative()
            .SetEase(_ease);
    }
}

