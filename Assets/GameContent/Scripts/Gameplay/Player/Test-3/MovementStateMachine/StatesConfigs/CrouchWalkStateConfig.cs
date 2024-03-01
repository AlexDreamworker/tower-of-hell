using System;
using UnityEngine;

[Serializable]
public class CrouchWalkStateConfig
{
    [SerializeField, Range(0, 100)] private float _speed = 5f;

    public float Speed => _speed;
}
