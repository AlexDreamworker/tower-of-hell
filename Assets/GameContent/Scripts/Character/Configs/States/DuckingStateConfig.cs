using System;
using UnityEngine;

[Serializable]
public class DuckingStateConfig
{
    [SerializeField, Range(0, 100)] private float _speed = 5f;

    public float Speed => _speed;
}
