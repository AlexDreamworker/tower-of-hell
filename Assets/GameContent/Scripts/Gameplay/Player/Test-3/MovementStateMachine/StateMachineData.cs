using System;

public class StateMachineData
{
    public float XVelocity;
    public float YVelocity;

    private float _speed;
    private float _xInput; //? VERTICAL?
    private float _yInput; //? HORIZONTAL?

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
