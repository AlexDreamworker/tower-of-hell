using UnityEngine;
using Zenject;

public class HUD : MonoBehaviour
{
    [SerializeField] private Context _context;

    private Level _level;

    [Inject]
    private void Construct(Level level) 
    {
        _level = level;
    }

    private void OnEnable()
    {
        _level.Started += OnLevelStarted;

        _context.Hide();
    }

    private void OnDisable()
    {
        _level.Started -= OnLevelStarted;
    }

    private void OnLevelStarted() 
        => _context.Show();
}
