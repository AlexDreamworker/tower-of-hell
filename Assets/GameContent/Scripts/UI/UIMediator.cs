using System;
using Zenject;

public class UIMediator : IDisposable
{
    private Level _level;
    private Curtain _curtain;
    private HUD _hud;
    private StartPanel _startPanel;
    private PausePanel _pausePanel;
    private DefeatPanel _defeatPanel;

    [Inject]
    private void Construct(
        Level level, 
        Curtain curtain,
        HUD hud, 
        StartPanel startPanel, 
        PausePanel pausePanel, 
        DefeatPanel defeatPanel) 
    {
        _level = level;
        _curtain = curtain;
        _hud = hud;
        _startPanel = startPanel;
        _pausePanel = pausePanel;
        _defeatPanel = defeatPanel;

        _level.Started += OnLevelStarted;
        _level.Restarted += OnLevelRestarted;
        _level.Paused += OnLevelPaused;
        _level.Continued += OnLevelContinued;
        _level.Completed += OnLevelCompleted;
        _level.Failed += OnLevelFailed;
    }

    public void Dispose()
    {
        _level.Started -= OnLevelStarted;
        _level.Restarted -= OnLevelRestarted;
        _level.Paused -= OnLevelPaused;
        _level.Continued -= OnLevelContinued;
        _level.Completed -= OnLevelCompleted;
        _level.Failed -= OnLevelFailed;
    }

    public void StartLevel() => _level.OnStarted();

    public void RestartLevel() => _level.OnRestarted();

    public void ContinueLevel() => _level.OnContinued();

    private void OnLevelStarted()
    {
        _startPanel.Hide();
        _hud.Show();
    }

    private void OnLevelRestarted() => _defeatPanel.Hide();

    private void OnLevelPaused() => _pausePanel.Show();

    private void OnLevelContinued() => _pausePanel.Hide();

    private void OnLevelCompleted() => _curtain.Show();

    private void OnLevelFailed() => _defeatPanel.Show();
}