using System;
using UnityEngine;

public class Level
{
    public event Action Started;
    public event Action Completed;
    public event Action Failed;

    private IInputService _input;
    private ICursorService _cursor;
    private Character _character;
    private CharacterCamera _camera;
    private CheckpointsHandler _checkpointsHandler;
    private Curtain _curtain; //TODO: move this?

    private Level(
        IInputService input, 
        ICursorService cursor, 
        Character character, 
        CharacterCamera camera,
        CheckpointsHandler checkpointsHandler,
        Curtain curtain)
    { 
        _input = input;
        _cursor = cursor;
        _character = character;
        _camera = camera;
        _checkpointsHandler = checkpointsHandler;
        _curtain = curtain;
    }

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
        _character.SetPosition(_checkpointsHandler.GetPoint());
        _cursor.Visible(false);

        _input.Enable();
    }

    //TODO: naming?
    public void OnCheckpointed(Vector3 point) 
        => _checkpointsHandler.SetPoint(point);

    //TODO: naming?
    public void OnCompleted()
    {
        //Debug.Log("((( ON COMPLETED )))");

        _curtain.Show();

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