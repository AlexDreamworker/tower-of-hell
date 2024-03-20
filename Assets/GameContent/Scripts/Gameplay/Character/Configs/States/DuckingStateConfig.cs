using System;
using UnityEngine;

[Serializable]
public class DuckingStateConfig
{
    [SerializeField, Range(0, 100)] private float _speed = 4f;

    public float Speed => _speed;
}