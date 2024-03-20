using Zenject;

public class MobileInput : BasePanel
{
    private Level _level;

    [Inject]
    private void Construct(Level level) 
        => _level = level;

    private void OnEnable()
    {
        _level.Started += OnLevelStarted;
        _level.Restarted += OnLevelRestarted;
        _level.Paused += OnLevelPaused;
        _level.Continued += OnLevelContinued;
        _level.Completed += OnLevelCompleted;
        _level.Failed += OnLevelFailed;

        Hide();
    }

    private void OnDisable()
    {
        _level.Started -= OnLevelStarted;
        _level.Restarted -= OnLevelRestarted;
        _level.Paused -= OnLevelPaused;
        _level.Continued -= OnLevelContinued;
        _level.Completed -= OnLevelCompleted;
        _level.Failed -= OnLevelFailed;
    }

    private void OnLevelStarted() => Show();

    private void OnLevelRestarted() => Show();

    private void OnLevelPaused() => Hide();

    private void OnLevelContinued() => Show();

    private void OnLevelCompleted() => Hide();

    private void OnLevelFailed() => Hide();
}