using System;
using UnityEngine;

//TODO: Rename to CHARACTER_STATE_MACHINE_DATA
public class StateMachineData
{
    //?public float XVelocity;
    //?public float YVelocity;

    public Vector3 MoveDirection; //!!!

    private float _speed;

    private float _xInput; //? VERTICAL?
    private float _yInput; //? HORIZONTAL?

    public int JumpsCount; //!!!

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
