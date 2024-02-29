using UnityEngine;

public class WalkState : GroundedState
{
    private readonly WalkStateConfig _config;

    public WalkState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig.WalkStateConfig;

    public override void Enter()
    {
        base.Enter();

        Debug.Log("<color=blue>WALK</color>"); //TODO: delete debug!

        Data.Speed = _config.Speed;
    }

    public override void Exit() => base.Exit();

    public override void HandleInput() => base.HandleInput();

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            StateSwitcher.SwitchState<IdleState>();
    }

    public override void FixedUpdate() => base.FixedUpdate();
}