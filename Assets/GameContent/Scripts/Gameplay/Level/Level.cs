using System;
using UnityEngine;
using Zenject;

//TODO: refact methods
public class Level : IInitializable, IDisposable
{
	public event Action<int> Initialized;
	public event Action Started;
	public event Action Restarted;
	public event Action Paused;
	public event Action Continued;
	public event Action Checkpointed;
	public event Action Completed;
	public event Action Failed;

	private IInputService _input;
	private IPauseService _pause;
	private ICursorService _cursor;
	private Character _character;
	private CharacterCamera _camera;
	private CheckpointsHandler _checkpointsHandler;
	private Curtain _curtain;
	private SceneLoadMediator _loader;
	private LevelLoadingData _levelData;

	private bool _isPaused = false;

	private Level(
		IInputService input,
		IPauseService pause,
		ICursorService cursor, 
		Character character, 
		CharacterCamera camera,
		CheckpointsHandler checkpointsHandler,
		Curtain curtain,
		SceneLoadMediator loader,
		LevelLoadingData levelData = null) //! "null" IS FOR TESTS
	{ 
		_input = input;
		_pause = pause;
		_cursor = cursor;
		_character = character;
		_camera = camera;
		_checkpointsHandler = checkpointsHandler;
		_curtain = curtain;
		_loader = loader;
		_levelData = levelData;

		_input.PauseKeyPressed += OnPausePressed;
	}
	
	public void Initialize()
	{
		_curtain.Hide();
		
//!-TESTING----------------------------------------------------------
		if (_levelData == null)
			Initialized?.Invoke(0);
		else 
			Initialized?.Invoke(_levelData.Level);
//!------------------------------------------------------------------

		//!Initialized?.Invoke(_levelData.Level);
	}

	public void Dispose()
		=> _input.PauseKeyPressed -= OnPausePressed;

	public void OnStarted()
	{ 
		_camera.Initialize(
			_input, 
			_character.Config, 
			_character.transform, 
			_character.CameraPoint);

		_input.Enable();
		_cursor.Visible(false);
		_character.StartWork();

		Started?.Invoke();
	}

	public void OnRestarted() 
	{
		_pause.Disable();

		_character.SetPosition(_checkpointsHandler.GetPoint());
		_cursor.Visible(false);

		_input.Enable();

		Restarted?.Invoke();
	}

	public void OnPaused()
	{
		_pause.Enable();
		_cursor.Visible(true);

		Paused?.Invoke();
	}

	public void OnContinued() 
	{
		_isPaused = false;

		_cursor.Visible(false);

		Continued?.Invoke();

		_pause.Disable();
	}

	public void OnCheckpointed(Vector3 point)
	{
		_checkpointsHandler.SetPoint(point);

		Checkpointed?.Invoke();
	} 

	public void OnCompleted()
	{
		_input.Disable();
		_character.StopWork();
		
		_curtain.Completed += OnReadyToNextLevel;
		_curtain.Show();

		Completed?.Invoke();
	}

	public void OnFailed()
	{
		_input.Disable();
		_pause.Enable();
		_cursor.Visible(true);

		Failed?.Invoke();
	}
	
	public void GoToMainMenu() 
	{
		_input.Disable();
		_character.StopWork();
		
		_curtain.Completed += OnReadyToMainMenu;
		_curtain.Show();
	}
	
	private void OnReadyToNextLevel() 
	{
		_curtain.Completed -= OnReadyToNextLevel;
		
		_cursor.Visible(true);
		_pause.Disable();

		LoadNextLevel();	
	}

	private void OnPausePressed()
	{
		_isPaused = !_isPaused;

		if (_isPaused)
			OnPaused();
		else
			OnContinued();    
	}
		
	private void OnReadyToMainMenu() 
	{
		_curtain.Completed -= OnReadyToMainMenu;
		
		_cursor.Visible(true);
		_pause.Disable();
		
		LoadMainMenu();
	}
	
	private void LoadNextLevel()
	{
		int nextLevel = _levelData.Level;
		nextLevel++;
		
		if (nextLevel >= Enum.GetValues(typeof(SceneID)).Length)
			LoadMainMenu();
		else 
			_loader.GoToLevel((SceneID)nextLevel, new LevelLoadingData(nextLevel));

	}
	private void LoadMainMenu() => _loader.GoToMainMenu();
}