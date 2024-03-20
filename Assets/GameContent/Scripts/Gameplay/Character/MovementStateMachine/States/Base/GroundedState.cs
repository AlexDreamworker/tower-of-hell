using UnityEngine;

public abstract class GroundedState : MovementState
{
    private readonly IObstacleDetector _groundDetector;
    private readonly GroundedStateConfig _config;

    protected GroundedState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groundDetector = character.GroundDetector;
        _config = character.Config.GroundedStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Rigidbody.drag = _config.Drag;
        Data.JumpsCount = 0;
    }

    public override void Update()
    {
        base.Update();
        
        if (_groundDetector.IsTouches == false)
            StateSwitcher.SwitchState<FallingState>();
    }
}
