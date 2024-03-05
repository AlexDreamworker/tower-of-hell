using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [Space]
    [SerializeField] private CharacterConfig _config;
    [Space]
    [SerializeField] private SphereObstacleDetector _groundDetector;
    [SerializeField] private SphereObstacleDetector _roofDetector;
    [SerializeField] private SphereObstacleDetector _wallDetector;

    private IInputService _input;
    private ILogService _log;

    private MovementStateMachine _stateMachine;
    private Rigidbody _rigidbody;

    [Inject]
    private void Construct(IInputService input, ILogService log) //TODO: move init StateMachine
    {
        _input = input;
        _log = log;

        _rigidbody = GetComponent<Rigidbody>();
        _stateMachine = new MovementStateMachine(this);
    }

    public IInputService Input => _input;
    public ILogService Log => _log;
    public IObstacleDetector GroundDetector => _groundDetector;
    public IObstacleDetector RoofDetector => _roofDetector;
    public IObstacleDetector WallDetector => _wallDetector;
    
    public Rigidbody Rigidbody => _rigidbody;
    public CharacterConfig Config => _config;

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void FixedUpdate() => _stateMachine.FixedUpdate();
}