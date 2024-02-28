using System;
using UnityEngine;

[Serializable]
public class WalkStateConfig
{
    [SerializeField, Range(0, 100)] private float _speed = 7f;

    public float Speed => _speed;
}
