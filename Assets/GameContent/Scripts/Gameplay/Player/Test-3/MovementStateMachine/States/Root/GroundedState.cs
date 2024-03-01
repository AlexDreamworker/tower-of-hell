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

    public override void Enter()
    {
        base.Enter();

        Data.JumpsCount = 0;
    }

    public override void Update()
    {
        base.Update();

        Rigidbody.drag = _config.Drag;

        if (_groundDetector.IsTouches == false)
            StateSwitcher.SwitchState<FallState>();
    }
}
