public abstract class LocomotionState : StandedState
{
    public LocomotionState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            StateSwitcher.SwitchState<IdleState>();
    }
}