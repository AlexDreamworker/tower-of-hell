public class StandingWalkState : StandingState
{
    private readonly StandingWalkStateConfig _config;

    public StandingWalkState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig.StandingStateConfig.StandingWalkStateConfig;

    public override void Enter()
    {
        base.Enter();

        Log.Log("WALK", TextColor.Blue);

        Data.Speed = _config.Speed;
    }

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            StateSwitcher.SwitchState<StandingIdleState>();
    }
}