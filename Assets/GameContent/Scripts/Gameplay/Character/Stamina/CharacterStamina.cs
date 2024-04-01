using System;
using UnityEngine;
using Zenject;

public class CharacterStamina : ITickable
{
	public event Action ValueChanged;
	public event Action Used;

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
		if (_currentStamina >= _config.Max)
			return;

		FillUp();
	}

	public bool CanUse(StateType state) 
	{
		return _currentStamina > Rate(state);
	}

	public void Use(StateType state) 
	{
		_currentStamina -= Rate(state);
		Used?.Invoke();
	}
	
	public void Reset()
	{
		_currentStamina = Max;
		ValueChanged?.Invoke();
	}

	private void FillUp() 
	{
		_currentStamina += _config.IncreaseMultiplier * Time.deltaTime;
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