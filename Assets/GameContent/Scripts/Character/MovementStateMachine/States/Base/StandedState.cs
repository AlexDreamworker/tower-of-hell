using UnityEngine;

public abstract class StandedState : GroundedState
{
    private readonly StandedStateConfig _config;

    public StandedState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig.StandedStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.YScale = _config.YScale;
        Transform.localScale = new Vector3(Transform.localScale.x, Data.YScale, Transform.localScale.z);
    }

    public override void Update()
    {
        base.Update();

        if (Input.IsJump)
            StateSwitcher.SwitchState<JumpingState>();
    }

    protected override void AddInputActionCallbacks() 
    { 
        base.AddInputActionCallbacks();

        Input.CrouchKeyPressed += OnCrouchKeyPressed;
        Input.JumpKeyStarted += OnJumpKeyStarted;
        Input.DashKeyPressed += OnDashKeyPressed;
    }

    protected override void RemoveInputActionCallbacks() 
    { 
        base.RemoveInputActionCallbacks();

        Input.CrouchKeyPressed -= OnCrouchKeyPressed;
        Input.JumpKeyStarted -= OnJumpKeyStarted;
        Input.DashKeyPressed -= OnDashKeyPressed;
    }

    private void OnCrouchKeyPressed() => StateSwitcher.SwitchState<CrouchingState>();

    private void OnJumpKeyStarted() => StateSwitcher.SwitchState<JumpingState>();

    private void OnDashKeyPressed() => StateSwitcher.SwitchState<DashState>();
}