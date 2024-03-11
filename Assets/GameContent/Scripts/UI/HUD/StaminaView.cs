using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StaminaView : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private Gradient _gradient;
    
    private CharacterStamina _stamina;

    [Inject]
    private void Construct(CharacterStamina stamina) 
    {
        _stamina = stamina;
    }

    private void Update() => UpdateBar();

    private void UpdateBar() 
    {
        float value = _stamina.Current / _stamina.Max;
        _bar.fillAmount = value;
        _bar.color = _gradient.Evaluate(value);
    }
}