using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;

    protected IInput Input => _character.Input;
    protected Rigidbody Rigidbody => _character.Rigidbody;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    public void Enter()
    {
        Debug.Log(GetType());

        AddInputActionCallbacks();
    }

    public void Exit()
    {
        RemoveInputActionCallbacks();
    }

    public void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.YInput = ReadVerticalInput();

        Data.XVelocity = Data.XInput * Data.Speed;
    }

    public void Update()
    {
        //Vector3 velocity = GetConvertedVelocity();

        //CharacterController.Move(velocity * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    protected virtual void AddInputActionCallbacks() { }
    protected virtual void RemoveInputActionCallbacks() { }

    protected bool IsHorizontalInputZero() => Data.XInput == 0;

    private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity, 0);

    private float ReadHorizontalInput() => Input.Movement.x;
    private float ReadVerticalInput() => Input.Movement.y;
}
