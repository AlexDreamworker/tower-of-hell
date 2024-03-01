using System;
using UnityEngine;

[Serializable]
public class StandingStateConfig
{
    [SerializeField, Range(0, 5)] private float _yScale = 1f;

    [Space]
    [SerializeField] private StandingWalkStateConfig _standingWalkStateConfig;

    public float YScale => _yScale;

    public StandingWalkStateConfig StandingWalkStateConfig => _standingWalkStateConfig;
}
