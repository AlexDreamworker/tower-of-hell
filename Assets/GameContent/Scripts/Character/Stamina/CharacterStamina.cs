using System;
using UnityEngine;
using Zenject;

public class CharacterStamina : ITickable
{
    private float _currentStamina;

    private CharacterStaminaConfig _config;

    private CharacterStamina(CharacterConfig characterConfig) 
    {
        _config = characterConfig.StaminaConfig;

        _currentStamina = _config.Max;
    }

    public void Tick()
    {
        Debug.Log($"STAMINA: {_currentStamina}");

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
