using DG.Tweening;
using UnityEngine;

//TODO: Magic numbers
public class Mover : MonoBehaviour
{
    [Space]
    [SerializeField, Range(0, 50f)] private float _duration = 5f;
    [SerializeField] private Ease _ease = Ease.InOutSine;

    [Space]
    [SerializeField] private bool _isDebug;

    [Space]
    [SerializeField] private Transform[] _points;

    private int _currentPointId;

    private void Start() => Move();

    private void Move() 
    {
        transform.DOMove(_points[_currentPointId].position, _duration)
            .SetEase(_ease)
            .OnComplete(() => 
            {
                if (_currentPointId < _points.Length - 1)
                    _currentPointId += 1;
                else 
                    _currentPointId = 0;

                Move();
            });
    }

    private void OnDrawGizmos()
    {
        if (_isDebug == false)
            return;

        if (_points == null || _points.Length < 2)
            return;

        Gizmos.color = Color.yellow;

        foreach (Transform point in _points)
            Gizmos.DrawWireSphere(point.position, 0.4f);

        for (int i = 0; i < _points.Length - 1; i++)
            Gizmos.DrawLine(_points[i].position, _points[i + 1].position);

        Gizmos.DrawLine(_points[_points.Length - 1].position, _points[0].position);
    }
}