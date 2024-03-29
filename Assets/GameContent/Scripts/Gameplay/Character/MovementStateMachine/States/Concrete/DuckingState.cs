public class DuckingState : CrouchedState
{
    private readonly DuckingStateConfig _config;

    public DuckingState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig.CrouchedStateConfig.DuckingStateConfig;

    public override void Enter()
    {
        base.Enter();

        SetStateInfo(GetType(), TextColor.White);

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

        if (IsMovementInputZero())
            StateSwitcher.SwitchState<CrouchingState>();
    }
}