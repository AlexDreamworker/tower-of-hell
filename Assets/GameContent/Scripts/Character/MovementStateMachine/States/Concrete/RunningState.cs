public class RunningState : LocomotionState
{
    private readonly RunningStateConfig _config;
    private readonly ICamera _camera;

    public RunningState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.GroundedStateConfig.StandedStateConfig.RunningStateConfig;
        _camera = character.Camera;
    }

    public override void Enter()
    {
        base.Enter();

        SetStateInfo(GetType(), TextColor.Cyan);

        Data.Speed = _config.Speed;

        _camera.SetFOV(_config.EffectFOV, _config.TimeToSetFOV);
    }

    public override void Exit()
    {
        base.Exit();

        _camera.ResetFOV(_config.TimeToResetFOV);
    }

    public override void Update()
    {
        base.Update();

        if (Input.IsSprint == false)
            StateSwitcher.SwitchState<WalkingState>();
    }
}
