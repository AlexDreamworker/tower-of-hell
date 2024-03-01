using System;
using UnityEngine;

[Serializable]
public class GroundedStateConfig
{
    [SerializeField, Range(0, 100)] private float _drag = 5f;

    [Space]
    [SerializeField] private StandingStateConfig _standingStateConfig;
    [SerializeField] private CrouchingStateConfig _crouchingStateConfig; 

    public float Drag => _drag;

    public StandingStateConfig StandingStateConfig => _standingStateConfig;
    public CrouchingStateConfig CrouchingStateConfig => _crouchingStateConfig; 
}
