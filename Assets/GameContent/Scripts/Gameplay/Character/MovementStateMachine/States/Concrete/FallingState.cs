public class FallingState : AirborneState
{
    private readonly IObstacleDetector _groundDetector;

    public FallingState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundDetector = character.GroundDetector;

    public override void Enter()
    {
        base.Enter();

        SetStateInfo(GetType(), TextColor.Red);

        View.StartIdling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdling();
    }

    public override void Update()
    {
        base.Update();

        if (_groundDetector.IsTouches)
        {
            if (Input.IsJump)
            {
                Data.JumpsCount = 0;
                StateSwitcher.SwitchState<JumpingState>();
            }
            else
            {
                StateSwitcher.SwitchState<IdleState>();
            }
        }
    }
}