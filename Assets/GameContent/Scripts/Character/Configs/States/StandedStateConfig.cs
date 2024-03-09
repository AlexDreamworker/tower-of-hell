using System;
using UnityEngine;

[Serializable]
public class StandedStateConfig
{
    [SerializeField, Range(0, 5)] private float _yScale = 1f;

    [Space]
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    
    [Space]
    [SerializeField] private RunningStateConfig _runningStateConfig;

    public float YScale => _yScale;

    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
    public RunningStateConfig RunningStateConfig => _runningStateConfig;
}
