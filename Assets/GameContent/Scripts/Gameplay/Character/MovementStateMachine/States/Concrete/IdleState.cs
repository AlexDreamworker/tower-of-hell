public class IdleState : StandedState
{
    public IdleState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }

    public override void Enter()
    {
        base.Enter();

        SetStateInfo(GetType(), TextColor.Lime);

        View.StartIdling();

        Data.Speed = 0;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdling();
    }

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            return;

        if (Input.IsWalk)
            StateSwitcher.SwitchState<WalkingState>();
        else 
            StateSwitcher.SwitchState<RunningState>();
    }
}