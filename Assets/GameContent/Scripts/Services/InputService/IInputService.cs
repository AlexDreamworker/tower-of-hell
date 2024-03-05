using System;
using UnityEngine;

public interface IInputService
{
    event Action PauseKeyPressed;

    event Action JumpKeyStarted;
    event Action JumpKeyPerformed;

    event Action CrouchKeyPressed;

    event Action DashKeyPressed;

    Vector2 Movement { get; }
    Vector2 Look { get; }
    bool IsJump { get; }
    bool IsSprint { get; }
}