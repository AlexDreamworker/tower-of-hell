using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [Space]
    [SerializeField] private Transform _cameraPoint;

    [Space]
    [SerializeField] private SphereObstacleDetector _groundDetector;
    [SerializeField] private SphereObstacleDetector _roofDetector;
    [SerializeField] private SphereObstacleDetector _wallDetector;

    private IInputService _input;
    private ILogService _log;
    private CharacterConfig _config;
    private CharacterCamera _camera;

    private MovementStateMachine _stateMachine;
    private Rigidbody _rigidbody;

    [Inject]
    private void Construct(IInputService input, ILogService log, CharacterConfig config, CharacterCamera camera) 
    {
        _input = input;
        _log = log;
        _config = config;
        _camera = camera;

        _camera.Initialization(transform, _cameraPoint);
        _rigidbody = GetComponent<Rigidbody>();

        //TODO: move init StateMachine
        _stateMachine = new MovementStateMachine(this);
    }

    public IInputService Input => _input;
    public IObstacleDetector GroundDetector => _groundDetector;
    public IObstacleDetector RoofDetector => _roofDetector;
    public IObstacleDetector WallDetector => _wallDetector;
    
    public Rigidbody Rigidbody => _rigidbody;
    public CharacterConfig Config => _config;
    public Transform CameraPoint => _cameraPoint;

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void FixedUpdate() => _stateMachine.FixedUpdate();

    public void LogStateInfo(Type type, string color) 
        => _log.LogState(type.ToString(), color);
}