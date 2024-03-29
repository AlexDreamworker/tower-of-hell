using System;
using UnityEngine;

[Serializable]
public class WalkingStateConfig
{
    [SerializeField, Range(0, 100)] private float _speed = 3f;

    public float Speed => _speed;
}
