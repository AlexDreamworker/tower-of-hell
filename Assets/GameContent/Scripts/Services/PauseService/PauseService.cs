using System;
using UnityEngine;
using Zenject;

public class PauseService : IPauseService, IDisposable
{
    public event Action<bool> PauseChanged;

    private const float NormalTimeScale = 1f;

    private IInputService _input;
    private ICursorService _cursor;

    private bool _isPaused;

    [Inject]
    private void Construct(IInputService input, ICursorService cursor) 
    {
        _input = input;
        _cursor = cursor;

        _input.PauseKeyPressed += OnPauseKeyPressed;
    }

    public bool IsPaused => _isPaused;

    public void Dispose()
        => _input.PauseKeyPressed -= OnPauseKeyPressed;

    private void OnPauseKeyPressed()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : NormalTimeScale;

        _cursor.Visible(_isPaused);

        PauseChanged?.Invoke(_isPaused);
    } 
}
