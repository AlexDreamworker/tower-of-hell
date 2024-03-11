using System;
using UnityEngine;

public class PauseService : IPauseService, IDisposable
{
    public event Action<bool> PauseChanged;

    private const float NormalTimeScale = 1f;

    private IInputService _input;
    private ICursorService _cursor;

    private bool _isPaused;

    private PauseService(IInputService input, ICursorService cursor) 
    {
        _input = input;
        _cursor = cursor;

        _input.PauseKeyPressed += OnPauseKeyPressed;
    }

    public bool IsPaused => _isPaused;

    public void Dispose()
        => _input.PauseKeyPressed -= OnPauseKeyPressed;

    public void SetPause(bool isPause) 
    {
        _isPaused = isPause;

        Time.timeScale = _isPaused ? 0 : NormalTimeScale;

        _cursor.Visible(_isPaused);

        PauseChanged?.Invoke(_isPaused);
    }

    private void OnPauseKeyPressed()
    {
        _isPaused = !_isPaused;

        SetPause(_isPaused);
        
        // Time.timeScale = _isPaused ? 0 : NormalTimeScale;

        // _cursor.Visible(_isPaused);

        // PauseChanged?.Invoke(_isPaused);
    } 
}
