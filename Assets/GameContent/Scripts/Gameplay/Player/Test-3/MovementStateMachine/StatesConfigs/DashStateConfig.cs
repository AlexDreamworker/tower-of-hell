using System;
using UnityEngine;

[Serializable]
public class DashStateConfig
{
    [SerializeField, Range(0, 100)] private float _speed = 20f; //TODO: not need this?
    [SerializeField, Range(0, 100)] private float _drag = 0f; //TODO: not need this?
    [SerializeField, Range(0, 100)] private float _force = 20f;
    [SerializeField, Range(0, 5)] private float _cooldown = 1.5f; //TODO: not need this?

    public float Speed => _speed; //TODO: not need this?
    public float Drag => _drag; //TODO: not need this?
    public float Force => _force;
    public float Cooldown => _cooldown; //TODO: not need this?
}