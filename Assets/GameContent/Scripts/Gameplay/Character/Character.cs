using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
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
	private Collider _collider;

	private bool _isWorking = false;

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
		_collider = GetComponent<Collider>();
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
		if (_isWorking == false)
			return;

		_stateMachine.HandleInput();
		_stateMachine.Update();
	}

	private void FixedUpdate()
	{
		if (_isWorking == false)
			return;

		_stateMachine.FixedUpdate();
	}

	public void StartWork() 
	{
		_view.StartWork();
		_stateMachine.StartWork();

		_isWorking = true;
	}

	public void StopWork()
	{
		_isWorking = false;

		_rigidbody.velocity = Vector3.zero;
	} 

	public void ReturnToCheckpoint(Vector3 position)
	{
		Rigidbody.position = position;
		
		_stamina.Reset();

		SetPhysicsActivity(true);		
	}
	
	public void Freeze() => SetPhysicsActivity(false);
	
	private void SetPhysicsActivity(bool isEnabled) 
	{
		_rigidbody.isKinematic = !isEnabled;
		_collider.enabled = isEnabled;
	}


//TODO: Testing
	public void LogStateInfo(Type type, string color) { }
		//!=> _log.LogState(type.ToString(), color);
}