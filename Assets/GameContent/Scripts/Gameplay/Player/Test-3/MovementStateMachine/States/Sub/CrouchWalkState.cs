using UnityEngine;

public class CrouchWalkState : CrouchingState
{
    private readonly CrouchWalkStateConfig _config;

    public CrouchWalkState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig.CrouchingStateConfig.CrouchWalkStateConfig;

    public override void Enter()
    {
        base.Enter();

        Debug.Log("<color=white>CROUCH WALK</color>"); //TODO: debug!

        Data.Speed = _config.Speed;
    }

    public override void Update()
    {
        base.Update();

        if (IsMovementInputZero())
            StateSwitcher.SwitchState<CrouchIdleState>();
    }
}