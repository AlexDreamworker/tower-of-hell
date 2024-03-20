using System;
using UnityEngine;

public class Level : IDisposable
{
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

    private bool _isPaused = false;

    private Level(
        IInputService input,
        IPauseService pause,
        ICursorService cursor, 
        Character character, 
        CharacterCamera camera,
        CheckpointsHandler checkpointsHandler)
    { 
        _input = input;
        _pause = pause;
        _cursor = cursor;
        _character = character;
        _camera = camera;
        _checkpointsHandler = checkpointsHandler;

        _input.PauseKeyPressed += OnPausePressed;
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

        Completed?.Invoke();
    }

    public void OnFailed()
    {
        _input.Disable();
        _pause.Enable();
        _cursor.Visible(true);

        Failed?.Invoke();
    }

    public void LoadNextLevel() { }

    private void OnPausePressed()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
            OnPaused();
        else
            OnContinued();    
    }
}