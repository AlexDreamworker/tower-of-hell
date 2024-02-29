using UnityEngine;

public abstract class GroundedState : MovementState
{
    private readonly GroundChecker _groundChecker;
    private readonly GroundedStateConfig _config;

    protected GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groundChecker = character.GroundChecker;
        _config = character.Config.GroundedStateConfig;
    }

    public override void Enter() => base.Enter();

    public override void Exit() => base.Exit();

    public override void HandleInput() => base.HandleInput();

    public override void Update()
    {
        base.Update();

        Rigidbody.drag = _config.Drag;

        if (_groundChecker.IsTouches == false)
            StateSwitcher.SwitchState<FallState>();

        //TODO: Not need this part in Crouch states
        if (Input.IsJump)
            StateSwitcher.SwitchState<JumpState>();
    }

    public override void FixedUpdate() => base.FixedUpdate();
}
