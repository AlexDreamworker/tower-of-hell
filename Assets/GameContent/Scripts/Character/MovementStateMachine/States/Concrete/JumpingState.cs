using UnityEngine;

public class JumpingState : AirborneState
{
    private readonly JumpingStateConfig _config;

    public JumpingState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.AirborneStateConfig.JumpingStateConfig;

    public override void Enter()
    {
        base.Enter();

        SetStateInfo(GetType(), TextColor.Yellow);

        Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);

        Rigidbody.AddForce(Transform.up * _config.Force, ForceMode.Impulse);

        Data.JumpsCount++;
    }

    public override void Update()
    {
        base.Update();

        if (Rigidbody.velocity.y < 0f)
            StateSwitcher.SwitchState<FallingState>();
    }
}