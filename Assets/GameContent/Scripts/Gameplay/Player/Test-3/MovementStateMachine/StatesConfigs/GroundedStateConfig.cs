using System;
using UnityEngine;

[Serializable]
public class GroundedStateConfig
{
    [SerializeField] private WalkStateConfig _walkStateConfig;

    [Space]
    [SerializeField, Range(0, 100)] private float _drag = 5f;

    public WalkStateConfig WalkStateConfig => _walkStateConfig;
    public float Drag => _drag;
}
