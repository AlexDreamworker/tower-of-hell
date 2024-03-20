using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Space]
    [SerializeField, Range(0, 50f)] private float _duration = 5f;
    [SerializeField] private Ease _ease = Ease.InOutSine;

    [Space]
    [SerializeField] private bool _isDebug;

    [Space]
    [SerializeField] private List<Transform> _points = new List<Transform>();

    private const int MinPointsToDraw = 2;
    private const float DrawSphereRadius = 0.4f;

    private int _currentPointId;

    private int PointsCount => _points.Count - 1;

    private void Start() => Move();

    private void Move() 
    {
        transform.DOMove(_points[_currentPointId].position, _duration)
            .SetEase(_ease)
            .OnComplete(() => 
            {
                if (_currentPointId < PointsCount)
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

        if (_points == null || _points.Count < MinPointsToDraw)
            return;

        Gizmos.color = Color.yellow;

        foreach (Transform point in _points)
            Gizmos.DrawWireSphere(point.position, DrawSphereRadius);

        for (int i = 0; i < PointsCount; i++)
            Gizmos.DrawLine(_points[i].position, _points[i + 1].position);

        Gizmos.DrawLine(_points[PointsCount].position, _points[0].position);
    }
}