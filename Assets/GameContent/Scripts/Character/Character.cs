using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [Space]
    [SerializeField] private CharacterView _view;
    [SerializeField] private Transform _cameraPoint;

    [Space]
    [SerializeField] private SphereObstacleDetector _groundDetector;
    [SerializeField] private SphereObstacleDetector _roofDetector;
    [SerializeField] private SphereObstacleDetector _wallDetector;

    private IInputService _input;
    private ILogService _log;
    private CharacterConfig _config;
    private CharacterCamera _camera;
    private CharacterStamina _stamina;
    private MovementStateMachine _stateMachine;

    private Rigidbody _rigidbody;

    [Inject]
    private void Construct(
        IInputService input, 
        ILogService log, 
        CharacterConfig config, 
        CharacterCamera camera,
        CharacterStamina stamina,
        MovementStateMachine stateMachine) 
    {
        _input = input;
        _log = log;
        _config = config;
        _camera = camera;
        _stamina = stamina;
        _stateMachine = stateMachine;

        _rigidbody = GetComponent<Rigidbody>();
    }

    public IInputService Input => _input;
    public IObstacleDetector GroundDetector => _groundDetector;
    public IObstacleDetector RoofDetector => _roofDetector;
    public IObstacleDetector WallDetector => _wallDetector;
    public ICamera Camera => _camera;
    
    public Rigidbody Rigidbody => _rigidbody;
    public CharacterConfig Config => _config;
    public CharacterView View => _view;
    public CharacterStamina Stamina => _stamina;
    public Transform CameraPoint => _cameraPoint;

    private void Start() => _view.Initialize();

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void FixedUpdate() => _stateMachine.FixedUpdate();

    public void StartWork() 
    {
        _view.StartWork();
        _stateMachine.StartWork();
    }

    public void SetPosition(Vector3 position) 
        => transform.position = position;

    public void LogStateInfo(Type type, string color)
        => _log.LogState(type.ToString(), color);
}