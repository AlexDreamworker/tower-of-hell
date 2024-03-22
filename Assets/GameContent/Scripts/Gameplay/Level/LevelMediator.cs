using System;
using Zenject;

public class LevelMediator : IDisposable
{
	private Level _level;
	private HUD _hud;
	private StartPanel _startPanel;
	private PausePanel _pausePanel;
	private DefeatPanel _defeatPanel;

	[Inject]
	private void Construct(
		Level level,
		HUD hud, 
		StartPanel startPanel, 
		PausePanel pausePanel, 
		DefeatPanel defeatPanel) 
	{
		_level = level;
		_hud = hud;
		_startPanel = startPanel;
		_pausePanel = pausePanel;
		_defeatPanel = defeatPanel;

		_level.Initialized += OnLevelInitialized;
		_level.Started += OnLevelStarted;
		_level.Restarted += OnLevelRestarted;
		_level.Paused += OnLevelPaused;
		_level.Continued += OnLevelContinued;
		_level.Failed += OnLevelFailed;
	}

	public void Dispose()
	{
		_level.Initialized += OnLevelInitialized;
		_level.Started -= OnLevelStarted;
		_level.Restarted -= OnLevelRestarted;
		_level.Paused -= OnLevelPaused;
		_level.Continued -= OnLevelContinued;
		_level.Failed -= OnLevelFailed;
	}

	private void OnLevelInitialized(int level)
	{
		_startPanel.SetLevelInfo(level);
		//?_pausePanel.SetLevelInfo(level);
	}

	public void StartLevel() => _level.OnStarted();

	public void RestartLevel() => _level.OnRestarted();

	public void ContinueLevel() => _level.OnContinued();
	
	public void GoToMainMenu() => _level.GoToMainMenu();

	private void OnLevelStarted()
	{
		_startPanel.Hide();
		_hud.Show();
	}

	private void OnLevelRestarted() => _defeatPanel.Hide();

	private void OnLevelPaused() => _pausePanel.Show();

	private void OnLevelContinued() => _pausePanel.Hide();

	private void OnLevelFailed() => _defeatPanel.Show();
}