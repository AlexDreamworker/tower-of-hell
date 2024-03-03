using UnityEngine;

public abstract class AirborneState : MovementState
{
    private readonly AirborneStateConfig _config;

    protected AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.AirborneStateConfig;

    public override void Enter()
    {
        base.Enter();

        Rigidbody.drag = _config.Drag;
        Data.Speed = _config.Speed;
    }

    protected override void AddInputActionCallbacks() 
    { 
        base.AddInputActionCallbacks();

        Input.JumpKeyStarted += OnJumpKeyStarted;
        Input.DashKeyPressed += OnDashKeyPressed;
    }

    protected override void RemoveInputActionCallbacks() 
    { 
        base.RemoveInputActionCallbacks();

        Input.JumpKeyStarted -= OnJumpKeyStarted;
        Input.DashKeyPressed -= OnDashKeyPressed;
    }

    private void OnJumpKeyStarted()
    {
        if (Data.JumpsCount >= _config.MaxJumpsCount)
            return;

        StateSwitcher.SwitchState<JumpState>();
    }

    private void OnDashKeyPressed() => StateSwitcher.SwitchState<DashState>();
}