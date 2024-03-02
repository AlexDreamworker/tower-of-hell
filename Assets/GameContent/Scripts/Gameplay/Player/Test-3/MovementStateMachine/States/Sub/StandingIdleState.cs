using UnityEngine;

public class StandingIdleState : StandingState
{
    public StandingIdleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("<color=green>IDLE</color>"); //TODO: debug!

        Data.Speed = 0;
    }

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            return;

        StateSwitcher.SwitchState<StandingWalkState>();
    }
}