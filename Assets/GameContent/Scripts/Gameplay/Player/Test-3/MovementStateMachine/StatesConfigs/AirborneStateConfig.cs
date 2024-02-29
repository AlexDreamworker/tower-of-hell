using System;
using UnityEngine;

[Serializable]
public class AirborneStateConfig
{
    [SerializeField] private JumpStateConfig _jumpStateConfig;

    [Space]
    [SerializeField, Range(0, 100)] private float _speed = 0.4f;
    [SerializeField, Range(0, 100)] private float _drag = 0f;

    public JumpStateConfig JumpStateConfig => _jumpStateConfig;
    public float Speed => _speed;
    public float Drag => _drag;
}
