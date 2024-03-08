using UnityEngine;

public abstract class MovementState : BaseState
{
    private readonly MovementStateConfig _config;

    protected MovementState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.MovementStateConfig;

    public override void HandleInput()
    {
        base.HandleInput();

        Data.MoveDirection = Transform.forward * Input.Movement.y + Transform.right * Input.Movement.x;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        MoveRigidbody();
        LimitFlatVelocity();
        ApplyAdditionalGravity();   
    }

    protected bool IsMovementInputZero() => Input.Movement == Vector2.zero;

    private void MoveRigidbody()
        => Rigidbody.AddForce(Data.MoveDirection.normalized * Data.Speed * _config.SpeedMultiplier, ForceMode.Force);

    private void ApplyAdditionalGravity()
        => Rigidbody.AddForce(Vector3.down * _config.AdditionalGravity, ForceMode.Force);

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
