using System;
using UnityEngine;

[Serializable]
public class CharacterStaminaConfig
{
    [SerializeField, Range(0, 10)] private int _max = 3;
    [SerializeField, Range(0, 10)] private int _dashRate = 1;
    [SerializeField, Range(0, 3)] private float _increaseMultiplier = 0.1f;

    public int Max => _max;
    public int DashRate => _dashRate;
    public float IncreaseMultiplier => _increaseMultiplier;
}
