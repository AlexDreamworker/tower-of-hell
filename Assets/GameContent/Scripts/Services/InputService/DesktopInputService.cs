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
    private bool _isWalk;

    public Vector2 Movement => _movement;
    public Vector2 Look => _look;
    public bool IsJump => _isJump;
    public bool IsWalk => _isWalk;

    public void Tick()
    {
        ReadAxisMovement();
        ReadAxisLook();

        ReadKeyJump();
        ReadKeyCrouch();
        ReadKeyWalk();
        ReadKeyDash();
        ReadKeyPause();
    }

    private void ReadAxisMovement()
        => _movement = new Vector2(Input.GetAxisRaw(HorizontalAxisKey), Input.GetAxisRaw(VerticalAxisKey));

    private void ReadAxisLook()
        => _look = new Vector2(Input.GetAxis(MouseXKey), Input.GetAxis(MouseYKey));

    private void ReadKeyJump()
    {
        if (Input.GetButtonDown(JumpKey))
            JumpKeyStarted?.Invoke();

        _isJump = Input.GetButton(JumpKey);

        if (Input.GetButtonUp(JumpKey))
            JumpKeyPerformed?.Invoke();
    }

    private void ReadKeyCrouch() 
    {
        if (Input.GetKeyDown(KeyCode.C))
            CrouchKeyPressed?.Invoke();
    }

    private void ReadKeyWalk()
        => _isWalk = Input.GetKey(KeyCode.LeftShift);

    private void ReadKeyDash()
    {
        if (Input.GetKeyDown(KeyCode.E))
            DashKeyPressed?.Invoke();
    }

    private void ReadKeyPause()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            PauseKeyPressed?.Invoke();
    }
}
