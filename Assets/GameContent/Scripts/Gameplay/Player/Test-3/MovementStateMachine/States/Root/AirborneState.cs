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

    //public override void Exit() => base.Exit();

    //public override void HandleInput() => base.HandleInput();

    //public override void Update() => base.Update();

    //public override void FixedUpdate() => base.FixedUpdate();

    protected override void AddInputActionCallbacks() 
    { 
        base.AddInputActionCallbacks();

        Input.JumpKeyStarted += OnJumpKeyStarted;
    }

    protected override void RemoveInputActionCallbacks() 
    { 
        base.RemoveInputActionCallbacks();

        Input.JumpKeyStarted -= OnJumpKeyStarted;
    }

    private void OnJumpKeyStarted()
    {
        if (Data.JumpsCount >= _config.MaxJumpsCount)
            return;

        StateSwitcher.SwitchState<JumpState>();
    }
}