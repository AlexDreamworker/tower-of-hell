public class FallingState : AirborneState
{
    private readonly IObstacleDetector _groundDetector;

    public FallingState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundDetector = character.GroundDetector;

    public override void Enter()
    {
        base.Enter();

        SetStateInfo(GetType(), TextColor.Red);
    }

    public override void Update()
    {
        base.Update();

        if (_groundDetector.IsTouches)
            StateSwitcher.SwitchState<IdleState>();
    }
}