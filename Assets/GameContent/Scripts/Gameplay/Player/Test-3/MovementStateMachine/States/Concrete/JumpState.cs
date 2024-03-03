using UnityEngine;

public class JumpState : AirborneState
{
    private readonly JumpStateConfig _config;

    public JumpState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.AirborneStateConfig.JumpStateConfig;

    public override void Enter()
    {
        base.Enter();

        Debug.Log("<color=yellow>JUMP</color>"); //TODO: debug!

        Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z); //TODO: need this?

        Rigidbody.AddForce(Transform.up * _config.Force, ForceMode.Impulse);

        Data.JumpsCount++;
    }

    public override void Update()
    {
        base.Update();

        if (Rigidbody.velocity.y < 0f)

            StateSwitcher.SwitchState<FallState>();
    }
}