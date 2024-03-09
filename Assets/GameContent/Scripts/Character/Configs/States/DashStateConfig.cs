using System;
using UnityEngine;

[Serializable]
public class DashStateConfig
{
    [SerializeField, Range(0, 100)] private float _force = 50f;
    [SerializeField, Range(0, 5)] private float _distance = 5f;
    [SerializeField, Range(0, 5)] private float _cooldown = 1.5f; //???
    [SerializeField, Range(0, 150f)] private float _effectFOV = 100f;
    [SerializeField, Range(0, 1f)] private float _timeToSetFOV = 0.25f;
    [SerializeField, Range(0, 1f)] private float _timeToResetFOV = 0.25f;

    public float Force => _force;
    public float Distance => _distance;
    public float Cooldown => _cooldown; //???
    public float EffectFOV => _effectFOV;
    public float TimeToSetFOV => _timeToSetFOV;
    public float TimeToResetFOV => _timeToResetFOV;
}