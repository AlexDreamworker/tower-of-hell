using System;
using UnityEngine;

//TODO: Rename to CHARACTER_DATA???
public class MovementStateMachineData
{
    private Vector3 _moveDirection;
    private float _speed;
    private float _yScale;
    private float _dashCooldownTimer;
    private int _jumpsCount;

    public Vector3 MoveDirection
    {
        get => _moveDirection;
        set => _moveDirection = value;
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }

    public float YScale 
    {
        get => _yScale;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _yScale = value;
        }
    }

    public float DashCooldownTimer
    {
        get => _dashCooldownTimer;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _dashCooldownTimer = value;
        }
    }

    public int JumpsCount
    {
        get => _jumpsCount;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _jumpsCount = value;
        }
    }
}