using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [SerializeField, Range(0, 100)] private float _speed = 12f;
    [SerializeField, Range(0, 150f)] private float _effectFOV = 100f;
    [SerializeField, Range(0, 1f)] private float _timeToSetFOV = 0.25f;
    [SerializeField, Range(0, 1f)] private float _timeToResetFOV = 0.25f;

    public float Speed => _speed;
    public float EffectFOV => _effectFOV;
    public float TimeToSetFOV => _timeToSetFOV;
    public float TimeToResetFOV => _timeToResetFOV;
}