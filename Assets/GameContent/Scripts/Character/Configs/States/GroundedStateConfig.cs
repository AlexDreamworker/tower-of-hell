using System;
using UnityEngine;

[Serializable]
public class GroundedStateConfig
{
    [SerializeField, Range(0, 100)] private float _drag = 5f;

    [Space]
    [SerializeField] private StandedStateConfig _standedStateConfig;
    
    [Space]
    [SerializeField] private CrouchedStateConfig _crouchedStateConfig; 

    public float Drag => _drag;

    public StandedStateConfig StandedStateConfig => _standedStateConfig;
    public CrouchedStateConfig CrouchedStateConfig => _crouchedStateConfig; 
}
