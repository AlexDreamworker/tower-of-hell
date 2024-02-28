using UnityEngine;

public class IdleState : MovementState
{
    public IdleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = 0;
    }

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            return;

        StateSwitcher.SwitchState<WalkState>();
    }
}