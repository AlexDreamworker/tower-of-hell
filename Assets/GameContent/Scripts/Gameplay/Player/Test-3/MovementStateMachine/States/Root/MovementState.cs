using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected IInput Input => _character.Input;
    protected Rigidbody Rigidbody => _character.Rigidbody;
    protected Transform Transform => _character.transform;

    public virtual void Enter()
    {
        //Debug.Log(GetType());

        AddInputActionCallbacks();
    }

    public virtual void Exit() 
    { 
        RemoveInputActionCallbacks();
    }

    public virtual void HandleInput() //TODO: change X and Y to Vector2?
    {
        Data.XInput = ReadHorizontalInput();
        Data.YInput = ReadVerticalInput();

        Data.MoveDirection = _character.transform.forward * Data.YInput + _character.transform.right * Data.XInput;
    }

    public virtual void Update() 
    {
        // if (Rigidbody.velocity == Vector3.zero)
        //     return;

        // Debug.Log(Rigidbody.velocity);
    }

    public virtual void FixedUpdate()
    {
        //?Data.MoveDirection = _character.transform.forward * Data.YInput + _character.transform.right * Data.XInput;

        MoveRigidbody();
        LimitFlatVelocity();
        ApplyAdditionalGravity();   
    }

    protected virtual void AddInputActionCallbacks() { }
    protected virtual void RemoveInputActionCallbacks() { }

    protected bool IsMovementInputZero() => Input.Movement == Vector2.zero;

    private float ReadHorizontalInput() => Input.Movement.x;
    private float ReadVerticalInput() => Input.Movement.y;

    private void MoveRigidbody() //TODO: remove magic number
    {
        Rigidbody.AddForce(Data.MoveDirection.normalized * Data.Speed * 10f, ForceMode.Force);
    }

    private void ApplyAdditionalGravity() //TODO: remove magic number
    {
        Rigidbody.AddForce(Vector3.down * 10f, ForceMode.Force);
    }

    private void LimitFlatVelocity() 
    {
        Vector3 flatVelocity = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);

        if (flatVelocity.magnitude > Data.Speed) 
        {
            Vector3 limitedVelocity = flatVelocity.normalized * Data.Speed;
            Rigidbody.velocity = new Vector3(limitedVelocity.x, Rigidbody.velocity.y, limitedVelocity.z);
        }
    }
}
