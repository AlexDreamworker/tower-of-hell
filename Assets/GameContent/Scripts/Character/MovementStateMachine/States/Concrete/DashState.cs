using System.Collections;
using UnityEngine;

public class DashState : BaseState
{
    private readonly DashStateConfig _config;
    private MonoBehaviour _monoProvider;
    private readonly IObstacleDetector _groundDetector;
    private readonly IObstacleDetector _wallDetector;
    private readonly ICamera _camera;
    
    public DashState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.DashStateConfig;
        _monoProvider = character;
        _groundDetector = character.GroundDetector;
        _wallDetector = character.WallDetector;
        _camera = character.Camera;
    }

    public override void Enter()
    {
        SetStateInfo(GetType(), TextColor.Purple);

        _camera.SetFOV(_config.EffectFOV, _config.TimeToSetFOV);

        _monoProvider.StartCoroutine(DashRoutine());
    }

    public override void Exit()
    {
        base.Exit();

        _camera.ResetFOV(_config.TimeToResetFOV);
    }

    private IEnumerator DashRoutine()
    {
        Vector3 startPosition = Transform.position;

        Rigidbody.AddForce(Transform.forward * _config.Force, ForceMode.Impulse);

        yield return new WaitUntil(() 
            => Vector3.Distance(startPosition, Transform.position) >= _config.Distance || _wallDetector.IsTouches);

        Rigidbody.velocity = Vector3.zero;

        if (_groundDetector.IsTouches == false)
            StateSwitcher.SwitchState<FallingState>();
        else
            StateSwitcher.SwitchState<IdleState>();
    }
}