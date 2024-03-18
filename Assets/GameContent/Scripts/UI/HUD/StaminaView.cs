using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StaminaView : MonoBehaviour
{
    [Space]
    [SerializeField] private Image _bar;
    [SerializeField] private ScaleTweener _tweener;
    [SerializeField] private Gradient _gradient;
    
    private CharacterStamina _stamina;

    [Inject]
    private void Construct(CharacterStamina stamina) 
        => _stamina = stamina;

    private void OnEnable() 
    {
        _stamina.ValueChanged += OnValueChanged;
        _stamina.Used += OnUsed;
    }

    private void OnDisable()
    {
        _stamina.ValueChanged -= OnValueChanged; 
        _stamina.Used -= OnUsed;
    }

    private void OnValueChanged()
    {
        float value = _stamina.Current / _stamina.Max;
        _bar.fillAmount = value;
        _bar.color = _gradient.Evaluate(value);
    }

    private void OnUsed() => _tweener.Play();
}