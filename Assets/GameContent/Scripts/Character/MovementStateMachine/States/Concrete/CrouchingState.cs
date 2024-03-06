public class CrouchingState : CrouchedState
{
    public CrouchingState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }

    public override void Enter()
    {
        base.Enter();

        LogStateInfo(GetType(), TextColor.Orange);

        Data.Speed = 0;
    }

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            return;

        StateSwitcher.SwitchState<DuckingState>();
    }
}
