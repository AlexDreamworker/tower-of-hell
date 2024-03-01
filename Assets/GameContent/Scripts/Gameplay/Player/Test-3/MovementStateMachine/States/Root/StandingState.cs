using UnityEngine;

public class StandingState : GroundedState
{
    private readonly StandingStateConfig _config;

    public StandingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig.StandingStateConfig;

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
            StateSwitcher.SwitchState<JumpState>();
    }

    protected override void AddInputActionCallbacks() 
    { 
        base.AddInputActionCallbacks();

        Input.CrouchKeyPressed += OnCrouchKeyPressed;
        Input.JumpKeyStarted += OnJumpKeyStarted;
    }

    protected override void RemoveInputActionCallbacks() 
    { 
        base.RemoveInputActionCallbacks();

        Input.CrouchKeyPressed -= OnCrouchKeyPressed;
        Input.JumpKeyStarted -= OnJumpKeyStarted;
    }

    private void OnCrouchKeyPressed() => StateSwitcher.SwitchState<CrouchIdleState>();

    private void OnJumpKeyStarted() => StateSwitcher.SwitchState<JumpState>();
}