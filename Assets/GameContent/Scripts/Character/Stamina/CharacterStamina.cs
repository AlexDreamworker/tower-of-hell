using System;
using UnityEngine;
using Zenject;

public class CharacterStamina : ITickable
{
    public event Action ValueChanged;

    private float _currentStamina;

    private CharacterStaminaConfig _config;

    private CharacterStamina(CharacterConfig characterConfig) 
    {
        _config = characterConfig.StaminaConfig;

        _currentStamina = _config.Max;
    }

    public float Current => _currentStamina;
    public float Max => _config.Max;

    public void Tick()
    {
        if (_currentStamina < _config.Max)
            _currentStamina += _config.IncreaseMultiplier * Time.deltaTime;
        else if (_currentStamina > _config.Max)
            _currentStamina = _config.Max;
    }

    public bool CanUse(StateType state) 
    {
        return _currentStamina > Rate(state);
    }

    public void Use(StateType state) 
    {
        _currentStamina -= Rate(state);
        ValueChanged?.Invoke();
    } 

    private int Rate(StateType state) 
    {
        switch (state) 
        {
            case StateType.Dash:
                return _config.DashRate;

            default:
                throw new ArgumentException($"Unknown state type: {state}");
        }
    }
}
