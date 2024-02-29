using UnityEngine;

public class IdleState : GroundedState
{
    public IdleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) { }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("<color=green>IDLE</color>"); //TODO: delete debug!

        Data.Speed = 0;
    }

    public override void Exit() => base.Exit();

    public override void HandleInput() => base.HandleInput();

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            return;

        StateSwitcher.SwitchState<WalkState>();
    }

    public override void FixedUpdate() => base.FixedUpdate();
}