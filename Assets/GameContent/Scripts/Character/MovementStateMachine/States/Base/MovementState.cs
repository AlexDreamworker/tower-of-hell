using UnityEngine;

public abstract class MovementState : BaseState
{
    protected MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }

    public override void HandleInput() //TODO: change X and Y to Vector2?
    {
        Data.XInput = ReadHorizontalInput();
        Data.YInput = ReadVerticalInput();

        Data.MoveDirection = Transform.forward * Data.YInput + Transform.right * Data.XInput;
    }

    public override void FixedUpdate()
    {
        MoveRigidbody();
        LimitFlatVelocity();
        ApplyAdditionalGravity();   
    }

    protected bool IsMovementInputZero() => Input.Movement == Vector2.zero;

    private float ReadHorizontalInput() => Input.Movement.x;
    private float ReadVerticalInput() => Input.Movement.y;

    private void MoveRigidbody() //TODO: remove magic number
        => Rigidbody.AddForce(Data.MoveDirection.normalized * Data.Speed * 10f, ForceMode.Force);

    private void ApplyAdditionalGravity() //TODO: remove magic number
        => Rigidbody.AddForce(Vector3.down * 10f, ForceMode.Force);

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
