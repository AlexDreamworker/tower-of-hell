public class WalkingState : LocomotionState
{
    private readonly WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig.StandedStateConfig.WalkingStateConfig;

    public override void Enter()
    {
        base.Enter();

        SetStateInfo(GetType(), TextColor.Blue);

        View.StartWalking();

        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopWalking();
    }

    public override void Update()
    {
        base.Update();

        if (Input.IsWalk == false)
            StateSwitcher.SwitchState<RunningState>();
    }
}