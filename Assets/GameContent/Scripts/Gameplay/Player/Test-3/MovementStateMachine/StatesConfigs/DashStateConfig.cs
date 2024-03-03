using System;
using UnityEngine;

[Serializable]
public class DashStateConfig
{
    [SerializeField, Range(0, 100)] private float _force = 50f;
    [SerializeField, Range(0, 5)] private float _distance = 5f;
    [SerializeField, Range(0, 5)] private float _cooldown = 1.5f; //???

    public float Force => _force;
    public float Distance => _distance;
    public float Cooldown => _cooldown; //???
}