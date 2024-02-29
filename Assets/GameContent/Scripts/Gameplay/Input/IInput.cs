using System;
using UnityEngine;

public interface IInput
{
    event Action PauseKeyPressed;

    event Action JumpKeyStarted;
    event Action JumpKeyPerformed;

    Vector2 Movement { get; }
    Vector2 Look { get; }
    //?bool IsJump { get; }
    bool IsSprint { get; }
}