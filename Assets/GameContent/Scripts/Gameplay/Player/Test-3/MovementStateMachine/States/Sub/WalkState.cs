public class WalkState : MovementState
{
    private readonly WalkStateConfig _config;

    public WalkState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character)
        => _config = character.Config.WalkStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
    }

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            StateSwitcher.SwitchState<IdleState>();
    }
}
