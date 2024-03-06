public class RunningState : LocomotionState
{
    private readonly RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig.StandedStateConfig.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        SetStateInfo(GetType(), TextColor.Cyan);

        Data.Speed = _config.Speed;
    }

    public override void Update()
    {
        base.Update();

        if (Input.IsSprint == false)
            StateSwitcher.SwitchState<WalkingState>();
    }
}
