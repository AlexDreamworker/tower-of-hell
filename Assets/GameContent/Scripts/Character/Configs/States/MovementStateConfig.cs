using System;
using UnityEngine;

[Serializable]
public class MovementStateConfig
{
    [SerializeField, Range (0, 100f)] private float _speedMultiplier = 10f;
    [SerializeField, Range (0, 100f)] private float _additionalGravity = 10f;

    public float SpeedMultiplier => _speedMultiplier;
    public float AdditionalGravity => _additionalGravity;
}
