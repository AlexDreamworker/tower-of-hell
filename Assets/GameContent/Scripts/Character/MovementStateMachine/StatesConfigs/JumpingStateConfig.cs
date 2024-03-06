using System;
using UnityEngine;

[Serializable]
public class JumpingStateConfig
{
    [SerializeField, Range(0, 100)] private float _force = 10f;

    public float Force => _force; 
}