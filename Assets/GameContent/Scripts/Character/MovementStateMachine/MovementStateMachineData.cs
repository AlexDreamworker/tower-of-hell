using System;
using UnityEngine;

public class MovementStateMachineData
{
    //?public float XVelocity;
    //?public float YVelocity;

    public Vector3 MoveDirection; //!!!

    private float _speed;

    private float _xInput; //? VERTICAL?
    private float _yInput; //? HORIZONTAL?

    public int JumpsCount; //!!!
    public float YScale; //!!!
    //?public bool IsCrouching; //!!!

    public float DashCooldownTimer; //!!!

    public float XInput
    {
        get => _xInput;
        set
        {
            if(value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _xInput = value;
        }
    }

    public float YInput 
    {
        get => _yInput;
        set
        {
            if(value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _yInput = value;
        }
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
}
