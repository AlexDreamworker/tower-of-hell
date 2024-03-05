using UnityEngine;

public class RayObstacleDetector : MonoBehaviour, IObstacleDetector
{
    [SerializeField] private LayerMask _layer;
    [SerializeField, Range(1, 3)] private float _playerHeight = 2f;
    [SerializeField, Range(0, 2)] private float _raycastDistanceOffset = 0.1f;

    [Space]
    [SerializeField] private bool _debug = true;

    public bool IsTouches { get; private set; }
    private float HalfHeight => _playerHeight / 2f;

    private void Update()
    {
        IsTouches = Physics.Raycast(
            transform.position, 
            Vector3.down, 
            HalfHeight + _raycastDistanceOffset, 
            _layer
        ); 
    }

    private void OnDrawGizmos()
    {
        if (_debug == false)
            return;

        Gizmos.color = IsTouches ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * (HalfHeight + _raycastDistanceOffset));
    }
}
