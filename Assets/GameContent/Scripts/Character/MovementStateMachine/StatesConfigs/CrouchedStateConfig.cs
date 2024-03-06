using System;
using UnityEngine;

[Serializable]
public class CrouchedStateConfig
{
    [SerializeField, Range(0, 5)] private float _yScale = 0.5f;
    [SerializeField, Range(0, 10)] private float _gravityForce = 5f;

    [Space]
    [SerializeField] private DuckingStateConfig _duckingStateConfig;

    public float YScale => _yScale;
    public float GravityForce => _gravityForce;

    public DuckingStateConfig DuckingStateConfig => _duckingStateConfig;
}