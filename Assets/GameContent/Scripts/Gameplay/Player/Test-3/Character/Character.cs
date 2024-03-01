using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private SphereObstacleDetector _groundDetector;
    [SerializeField] private SphereObstacleDetector _roofDetector;

    private IInput _input;
    private MovementStateMachine _stateMachine;
    private Rigidbody _rigidbody;

    public IInput Input => _input;
    public IObstacleDetector GroundDetector => _groundDetector;
    public IObstacleDetector RoofDetector => _roofDetector;
    public Rigidbody Rigidbody => _rigidbody;
    public CharacterConfig Config => _config;

    [Inject]
    private void Construct(IInput input) //TODO: move init StateMachine
    {
        _input = input;

        _rigidbody = GetComponent<Rigidbody>();
        _stateMachine = new MovementStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void FixedUpdate() => _stateMachine.FixedUpdate();
}