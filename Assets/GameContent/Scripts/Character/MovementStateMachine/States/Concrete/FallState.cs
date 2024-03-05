public class FallState : AirborneState
{
    private readonly IObstacleDetector _groundDetector;

    public FallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundDetector = character.GroundDetector;

    public override void Enter()
    {
        base.Enter();

        Log.Log("FALL", TextColor.Red);
    }

    public override void Update()
    {
        base.Update();

        if (_groundDetector.IsTouches)
        {
            if (IsMovementInputZero())
                StateSwitcher.SwitchState<StandingIdleState>();
            else
                StateSwitcher.SwitchState<StandingWalkState>();
        }
    }
}