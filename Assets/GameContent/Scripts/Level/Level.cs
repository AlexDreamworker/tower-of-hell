using System;
using UnityEngine;
using Zenject;

public class Level : IInitializable, ITickable, IDisposable
{
    public event Action Completed;
    public event Action Failed;

    private IInputService _input;
    private ICursorService _cursor;
    private Character _character;
    private CharacterCamera _camera;

    private Level(IInputService input, ICursorService cursor, Character character, CharacterCamera camera)
    { 
        _input = input;
        _cursor = cursor;
        _character = character;
        _camera = camera;
    }

    public void Initialize() { }

    public void Tick() { }

    public void Dispose() { }

    public void Start()
    { 
        _camera.Initialize(
            _input, 
            _character.Config, 
            _character.transform, 
            _character.CameraPoint);

        _input.Enable();
        _cursor.Visible(false);
    }

    public void Restart() { }

    private void OnCompleted() => Completed?.Invoke();

    private void OnFailed() => Failed?.Invoke();
}