using System;
using UnityEngine;
using Zenject;

public class Level : IInitializable, ITickable, IDisposable
{
    public event Action Started;
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

//?--- NEED THIS? -------------------------------
    public void Initialize() { }

    public void Tick() { }

    public void Dispose() { }
//?----------------------------------------------

    public void Start()
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

    public void Restart() 
    { 
        _character.SetPosition();
        _cursor.Visible(false);

        _input.Enable();
    }

    //TODO: naming?
    public void OnCompleted()
    {
        Debug.Log("((( ON COMPLETED )))");

        Completed?.Invoke();

        //Curtain close
        //Load new level
    }

    //TODO: naming?
    public void OnFailed()
    {
        _input.Disable();

        _cursor.Visible(true);

        Failed?.Invoke();
    }
}