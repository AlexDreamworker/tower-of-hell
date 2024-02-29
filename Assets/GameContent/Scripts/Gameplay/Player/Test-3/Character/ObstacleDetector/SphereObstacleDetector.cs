using UnityEngine;

public class SphereObstacleDetector : MonoBehaviour, IObstacleDetector
{
    [SerializeField] private LayerMask _layer;
    [SerializeField, Range(0.01f, 1)] private float _distanceToCheck;

    [Space]
    [SerializeField] private bool _debug = true;

    public bool IsTouches { get; private set; }

    private void Update()
    {
        IsTouches = Physics.CheckSphere(transform.position, _distanceToCheck, _layer);
    }

    private void OnDrawGizmos()
    {
        if (_debug == false)
            return;

        Gizmos.color = IsTouches ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, _distanceToCheck);
    }
}
