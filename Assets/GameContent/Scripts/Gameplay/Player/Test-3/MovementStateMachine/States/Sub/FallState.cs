using UnityEngine;

public class FallState : AirborneState
{
    private readonly GroundChecker _groundChecker;

    public FallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        Debug.Log("<color=red>FALL</color>"); //TODO: delete debug!
    }

    public override void Exit() => base.Exit();

    public override void HandleInput() => base.HandleInput();

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
        {
            //Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);

            if (IsMovementInputZero())
                StateSwitcher.SwitchState<IdleState>();
            else
                StateSwitcher.SwitchState<WalkState>();
        }
    }

    public override void FixedUpdate() => base.FixedUpdate();
}