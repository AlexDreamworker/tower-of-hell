using UnityEngine;

public class FallState : AirborneState
{
    private readonly IObstacleDetector _groundDetector;

    public FallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundDetector = character.GroundDetector;

    public override void Enter()
    {
        base.Enter();

        Debug.Log("<color=red>FALL</color>"); //TODO: delete debug!
    }

    //public override void Exit() => base.Exit();

    //public override void HandleInput() => base.HandleInput();

    public override void Update()
    {
        base.Update();

        if (_groundDetector.IsTouches)
        {
            if (IsMovementInputZero())
                StateSwitcher.SwitchState<IdleState>();
            else
                StateSwitcher.SwitchState<WalkState>();
        }
    }

    //public override void FixedUpdate() => base.FixedUpdate();
}