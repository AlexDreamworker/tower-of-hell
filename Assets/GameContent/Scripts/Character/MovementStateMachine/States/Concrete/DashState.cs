using System.Collections;
using UnityEngine;

public class DashState : BaseState
{
    private readonly DashStateConfig _config;
    private MonoBehaviour _monoProvider;
    private readonly IObstacleDetector _groundDetector;
    private readonly IObstacleDetector _wallDetector;
    
    public DashState(IStateSwitcher stateSwitcher, MovementStateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.DashStateConfig;
        _monoProvider = character;
        _groundDetector = character.GroundDetector;
        _wallDetector = character.WallDetector;
    }

    public override void Enter()
    {
        SetStateInfo(GetType(), TextColor.Purple);

        _monoProvider.StartCoroutine(DashRoutine());
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