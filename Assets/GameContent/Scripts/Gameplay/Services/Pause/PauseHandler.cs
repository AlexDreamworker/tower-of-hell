using System;
using System.Collections.Generic;
using Zenject;

public class PauseHandler : IDisposable
{
    private List<IPause> _handlers = new List<IPause>();

    private IInput _input;

    private bool _isPaused;

    [Inject]
    private void Construct(IInput input) 
    {
        _input = input;

        _input.PauseKeyPressed += OnPauseKeyPressed;
    }

    public void Dispose()
    {
        _input.PauseKeyPressed -= OnPauseKeyPressed;

        _handlers.Clear();
    }

    public void Add(IPause handler) => _handlers.Add(handler);

    public void Remove(IPause handler) => _handlers.Remove(handler);

    public void SetPause(bool isPaused) 
    {
        foreach (IPause handler in _handlers)
            handler.SetPause(isPaused);
    }

    private void OnPauseKeyPressed()
    {
        _isPaused = !_isPaused;

        SetPause(_isPaused);
    } 
}
