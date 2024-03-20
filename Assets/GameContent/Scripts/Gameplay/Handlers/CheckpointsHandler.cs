using UnityEngine;

public class CheckpointsHandler
{
    private Vector3 _startPoint;
    private Vector3 _currentPoint;

    private bool _isPointed;

    private CheckpointsHandler(Vector3 startPoint) 
        => _startPoint = startPoint;

    public void SetPoint(Vector3 point) 
    {
        _currentPoint = point;
        _isPointed = true;
    }

    public Vector3 GetPoint() 
    {
        Vector3 point = _isPointed ? _currentPoint : _startPoint;
        return point;
    }
}
