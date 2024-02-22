using UnityEngine;

public interface IInput
{
    Vector2 Movement { get; }
    Vector2 Look { get; }
    bool IsJump { get; }
    bool IsSprint { get; }
}