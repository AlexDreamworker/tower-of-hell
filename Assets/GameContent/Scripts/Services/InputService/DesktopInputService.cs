using System;
using UnityEngine;
using Zenject;

public class DesktopInputService : IInputService, ITickable
{
    public event Action PauseKeyPressed;

    public event Action JumpKeyStarted;
    public event Action JumpKeyPerformed;

    public event Action CrouchKeyPressed;

    public event Action DashKeyPressed;

    private const string VerticalAxisKey = "Vertical";
    private const string HorizontalAxisKey = "Horizontal";
    private const string MouseXKey = "Mouse X";
    private const string MouseYKey = "Mouse Y";
    private const string JumpKey = "Jump";

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
        //TODO: naming!
        ProcessMovementChange();
        ProcessLookChange();
        ProcessJumpPressing();
        ProcessCrouchPressed();
        ProcessSprintPressing();
        ProcessDashPressed();
        ProcessPausePressed();
    }

    private void ProcessMovementChange()
        => _movement = new Vector2(Input.GetAxisRaw(HorizontalAxisKey), Input.GetAxisRaw(VerticalAxisKey));

    private void ProcessLookChange()
        => _look = new Vector2(Input.GetAxis(MouseXKey), Input.GetAxis(MouseYKey));

    private void ProcessJumpPressing()
    {
        if (Input.GetButtonDown(JumpKey))
            JumpKeyStarted?.Invoke();

        _isJump = Input.GetButton(JumpKey);

        if (Input.GetButtonUp(JumpKey))
            JumpKeyPerformed?.Invoke();
    }

    private void ProcessCrouchPressed() 
    {
        if (Input.GetKeyDown(KeyCode.C))
            CrouchKeyPressed?.Invoke();
    }

    private void ProcessSprintPressing()
        => _isSprint = Input.GetKey(KeyCode.LeftShift);

    private void ProcessDashPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
            DashKeyPressed?.Invoke();
    }

    private void ProcessPausePressed()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            PauseKeyPressed?.Invoke();
    }
}
