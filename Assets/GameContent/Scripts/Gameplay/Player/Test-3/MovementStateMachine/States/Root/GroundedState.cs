using UnityEngine;

public abstract class GroundedState : MovementState
{
    private readonly IObstacleDetector _groundDetector;
    private readonly GroundedStateConfig _config;

    protected GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groundDetector = character.GroundDetector;
        _config = character.Config.GroundedStateConfig;
    }

    public override void Enter() => base.Enter();

    public override void Exit() => base.Exit();

    public override void HandleInput() => base.HandleInput();

    public override void Update()
    {
        base.Update();

        Rigidbody.drag = _config.Drag;

        if (_groundDetector.IsTouches)
            return;

        if (_groundDetector.IsTouches == false)
            StateSwitcher.SwitchState<FallState>();

        // //TODO: Not need this part in Crouch states
        // if (Input.IsJump)
        //     StateSwitcher.SwitchState<JumpState>();
    }

    public override void FixedUpdate() => base.FixedUpdate();

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

    private void OnJumpKeyStarted() => StateSwitcher.SwitchState<JumpState>();
}
