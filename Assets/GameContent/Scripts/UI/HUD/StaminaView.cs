using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StaminaView : MonoBehaviour
{
    [Space]
    [SerializeField] private Image _barHolder;
    [SerializeField, Range(0, 3f)] private float _normalScale = 1f;
    [SerializeField, Range(0, 3f)] private float _animationScale = 1.1f;
    [SerializeField, Range(0, 2f)] private float _animationDuration = 0.5f;

    [Space]
    [SerializeField] private Image _bar;
    [SerializeField] private Gradient _gradient;
    
    private CharacterStamina _stamina;

    private Tween _animationSequence;

    [Inject]
    private void Construct(CharacterStamina stamina) 
    {
        _stamina = stamina;
    }

    private Transform Background => _barHolder.gameObject.transform;

    private void OnEnable()
        => _stamina.ValueChanged += OnValueChanged;

    private void OnDisable()
        => _stamina.ValueChanged -= OnValueChanged; 

    private void Update() => UpdateBar();

    private void UpdateBar() 
    {
        float value = _stamina.Current / _stamina.Max;
        _bar.fillAmount = value;
        _bar.color = _gradient.Evaluate(value);
    }

    private void OnValueChanged() 
    {
        _animationSequence = DOTween.Sequence()
            .Append(Background.DOScale(_animationScale, _animationDuration))
            .AppendInterval(_animationDuration)
            .Append(Background.DOScale(_normalScale, _animationDuration));
    }
}