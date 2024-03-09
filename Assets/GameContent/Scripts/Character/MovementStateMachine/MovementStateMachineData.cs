using System;
using UnityEngine;
using Zenject;

//TODO: Rename to CHARACTER_DATA???
public class MovementStateMachineData /*: ITickable*/
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

// //!>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//     //? CONFIG DATA:
//     public const int MAX_STAMINA = 3;
//     public const int DASH_RATE = 1;

//     //? DYNAMIC DATA:
//     private float CurrentStamina = MAX_STAMINA;

//     //? LOGIC:
//     public void Tick()
//     {
//         Debug.Log($"STAMINA: {CurrentStamina}");

//         if (CurrentStamina < MAX_STAMINA)
//         {
//             CurrentStamina += 0.4f * Time.deltaTime;
//         }
//         else if (CurrentStamina > MAX_STAMINA)
//         {
//             CurrentStamina = MAX_STAMINA;
//         }
//     }

//     public bool CanDash() 
//     {
//         return CurrentStamina > DASH_RATE;
//     }

//     public void Decrease() 
//     {
//         CurrentStamina -= DASH_RATE;
//     }
// //!>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
}