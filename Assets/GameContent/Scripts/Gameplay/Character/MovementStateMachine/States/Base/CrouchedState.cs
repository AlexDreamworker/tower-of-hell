using UnityEngine;

public abstract class CrouchedState : GroundedState
{
    private readonly IObstacleDetector _roofDetector;
    private readonly CrouchedStateConfig _config;

    public CrouchedState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _roofDetector = character.RoofDetector;
        _config = character.Config.GroundedStateConfig.CrouchedStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Data.YScale = _config.YScale;

        Transform.localScale = new Vector3(Transform.localScale.x, Data.YScale, Transform.localScale.z);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Rigidbody.AddForce(Vector3.down * _config.GravityForce, ForceMode.Impulse);
    }

    protected override void AddInputActionCallbacks() 
    { 
        base.AddInputActionCallbacks();

        Input.CrouchKeyPressed += OnCrouchKeyPressed;
    }

    protected override void RemoveInputActionCallbacks() 
    { 
        base.RemoveInputActionCallbacks();

        Input.CrouchKeyPressed -= OnCrouchKeyPressed;
    }

    private void OnCrouchKeyPressed()
    {
        if (_roofDetector.IsTouches)
            return;

        StateSwitcher.SwitchState<IdleState>();
    }
}
