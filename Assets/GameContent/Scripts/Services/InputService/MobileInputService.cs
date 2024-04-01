using System;
using UnityEngine;
using Zenject;

public class MobileInputService : IInputService, ITickable
{
    public event Action PauseKeyPressed;
    public event Action JumpKeyStarted;
    public event Action JumpKeyPerformed;
    public event Action CrouchKeyPressed;
    public event Action DashKeyPressed;

    private const string VerticalAxisKey = "Vertical";
    private const string HorizontalAxisKey = "Horizontal";
    private const string MouseXKey = "Mouse X Mobile";
    private const string MouseYKey = "Mouse Y Mobile";

    private Vector2 _movement;
    private Vector2 _look;
    private bool _isJump;
    private bool _isWalk;

    private bool _isEnable;

    public Vector2 Movement => _movement;
    public Vector2 Look => _look;
    public bool IsJump => _isJump;
    public bool IsWalk => _isWalk;

    public void Tick()
    {
        if (_isEnable == false) 
            return;
            
        ReadAxisMovement();
        ReadAxisLook();

        ReadKeyJump();
        ReadKeyCrouch();
        ReadKeyWalk();
        ReadKeyDash();
        ReadKeyPause();
    }

    public void Enable() => _isEnable = true;

    public void Disable() => _isEnable = false;

    private void ReadAxisMovement()
        => _movement = new Vector2(SimpleInput.GetAxisRaw(HorizontalAxisKey), SimpleInput.GetAxisRaw(VerticalAxisKey));

    private void ReadAxisLook()
        => _look = new Vector2(SimpleInput.GetAxis(MouseXKey), SimpleInput.GetAxis(MouseYKey));

    private void ReadKeyJump()
    {
        if (SimpleInput.GetKeyDown(KeyCode.Space))
            JumpKeyStarted?.Invoke();

        _isJump = SimpleInput.GetKey(KeyCode.Space);

        if (SimpleInput.GetKeyUp(KeyCode.Space))
            JumpKeyPerformed?.Invoke();
    }

    private void ReadKeyCrouch()
    {
        if (SimpleInput.GetKeyDown(KeyCode.C))
            CrouchKeyPressed?.Invoke();
    }

    private void ReadKeyWalk()
        => _isWalk = SimpleInput.GetKey(KeyCode.LeftShift);

    private void ReadKeyDash()
    {
        if (SimpleInput.GetKeyDown(KeyCode.E))
            DashKeyPressed?.Invoke();
    }

    private void ReadKeyPause()
    {
        if (SimpleInput.GetKeyDown(KeyCode.Tab) || SimpleInput.GetKeyDown(KeyCode.Escape))
            PauseKeyPressed?.Invoke();
    }
}
