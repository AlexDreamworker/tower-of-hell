using UnityEngine;
using Zenject;

public class HUD : MonoBehaviour
{
    [SerializeField] private StaminaView _staminaView;

    private Level _level;

    [Inject]
    private void Construct(Level level) 
    {
        _level = level;
    }

    private void OnEnable()
    {
        _level.Started += OnLevelStarted;

        _staminaView.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _level.Started -= OnLevelStarted;
    }

    private void OnLevelStarted() 
        => _staminaView.gameObject.SetActive(true);
}
