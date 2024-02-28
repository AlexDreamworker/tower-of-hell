using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action PausePressed;

    private const string VERTICAL_KEY = "Vertical";
    private const string HORIZONTAL_KEY = "Horizontal";
    private const string MOUSE_X_KEY = "Mouse X";
    private const string MOUSE_Y_KEY = "Mouse Y";
    private const string JUMP_KEY = "Jump";

    private Vector2 _movement;
    private Vector2 _look;
    private bool _isJump;
    private bool _isSprint;

    public Vector2 Movement => _movement;
    public Vector2 Look => _look;
    public bool IsJump => _isJump;
    public bool IsSprint => _isSprint;

    public void Tick()
    {
        ProcessMovementChange();
        ProcessLookChange();
        ProcessJumpPressing();
        ProcessSprintPressing();
        ProcessPausePressed();
    }

    private void ProcessMovementChange()
        => _movement = new Vector2(Input.GetAxisRaw(HORIZONTAL_KEY), Input.GetAxisRaw(VERTICAL_KEY));

    // private void ProcessMovementChange()
    // {
    //     float horizontalInput = Input.GetAxis(HORIZONTAL_KEY);
    //     float verticalInput = Input.GetAxis(VERTICAL_KEY);

    //     if (Mathf.Approximately(horizontalInput, 0f) && Mathf.Approximately(verticalInput, 0f))
    //         _movement = Vector2.zero;
    //     else
    //         _movement = new Vector2(horizontalInput, verticalInput);
    // }

    private void ProcessLookChange()
        => _look = new Vector2(Input.GetAxis(MOUSE_X_KEY), Input.GetAxis(MOUSE_Y_KEY));

    private void ProcessJumpPressing()
        => _isJump = Input.GetButton(JUMP_KEY); //???

    private void ProcessSprintPressing()
        => _isSprint = Input.GetKey(KeyCode.LeftShift);

    private void ProcessPausePressed()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            PausePressed?.Invoke();
    }
}
