using System;
using UnityEngine;

[Serializable]
public class AirborneStateConfig
{
    [SerializeField, Range(0, 100)] private float _speed = 7f;
    [SerializeField, Range(0, 100)] private float _drag = 0f;
    [SerializeField, Range(0, 5)] private int _maxJumpsCount = 2;

    [Space]
    [SerializeField] private JumpingStateConfig _jumpingStateConfig;

    public float Speed => _speed;
    public float Drag => _drag;
    public float MaxJumpsCount => _maxJumpsCount;
    
    public JumpingStateConfig JumpingStateConfig => _jumpingStateConfig;
}
