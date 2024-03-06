public class IdleState : StandedState
{
    public IdleState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }

    public override void Enter()
    {
        base.Enter();

        SetStateInfo(GetType(), TextColor.Lime);

        Data.Speed = 0;
    }

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            return;

        if (Input.IsSprint)
            StateSwitcher.SwitchState<RunningState>();
        else 
            StateSwitcher.SwitchState<WalkingState>();
    }
}