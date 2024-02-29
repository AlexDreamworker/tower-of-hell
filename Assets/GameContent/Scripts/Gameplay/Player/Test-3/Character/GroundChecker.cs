using UnityEngine;

public class GroundChecker : MonoBehaviour //TODO: rename to OBSTACLE DETECTOR
{
    [SerializeField] private LayerMask _ground;
    [SerializeField, Range(1, 3)] private float _playerHeight = 2f;
    [SerializeField, Range(0, 2)] private float _raycastDistanceOffset = 0.1f;

    [SerializeField] private bool _debugRaycast = true;

    public bool IsTouches { get; private set; }
    private float HalfHeight => _playerHeight / 2f;

    private void Update()
    {
        IsTouches = Physics.Raycast(
            transform.position, 
            Vector3.down, 
            HalfHeight + _raycastDistanceOffset, 
            _ground
        ); 
    }

    private void OnDrawGizmos()
    {
        if (_debugRaycast == false)
            return;

        Gizmos.color = IsTouches ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * (HalfHeight + _raycastDistanceOffset));
    }
}
