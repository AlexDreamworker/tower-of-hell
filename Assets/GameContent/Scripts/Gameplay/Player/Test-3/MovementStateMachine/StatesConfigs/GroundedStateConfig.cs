using System;
using UnityEngine;

[Serializable]
public class GroundedStateConfig
{
    [SerializeField, Range(0, 100)] private float _drag = 5f;

    [Space]
    [SerializeField] private WalkStateConfig _walkStateConfig;

    public WalkStateConfig WalkStateConfig => _walkStateConfig;
    public float Drag => _drag;
}
