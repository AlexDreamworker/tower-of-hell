using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CharacterCamera : MonoBehaviour, ICamera
{
	private IInputService _input;
	private CharacterCameraConfig _config;
	private Transform _character;
	private Transform _targetPoint;
	private Camera _camera;

	private float _xRotation;
	private float _yRotation;

	private bool _isInit;
	
	private Tween _tween;
	
	private bool _isWork; //TODO: ???

	public void Initialize(IInputService input, CharacterConfig config, Transform character, Transform point)
	{
		_input = input;
		_config = config.CameraConfig;
		_character = character;
		_targetPoint = point;

		_camera = GetComponent<Camera>();

		_isInit = true;
	}

//*-OLD--------------------------------------------------------------
	// private void Update()
	// {
	// 	if (_isInit == false)
	// 		return;

	// 	UpdatePosition();
	// }

	// private void LateUpdate()
	// {
	// 	if (_isInit == false)
	// 		return;
			
	// 	float mouseX = _input.Look.x * Time.deltaTime * _config.XSensitivity;
	// 	float mouseY = _input.Look.y * Time.deltaTime * _config.YSensitivity;

	// 	_yRotation += mouseX;

	// 	_xRotation -= mouseY;
	// 	_xRotation = Mathf.Clamp(_xRotation, _config.XClampRotationMin, _config.XClampRotationMax);

	// 	transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
	// 	_character.rotation = Quaternion.Euler(0, _yRotation, 0);
	// }
//*------------------------------------------------------------------
	
//TODO: new test	
//!------------------------------------------------------------------
	
	private void FixedUpdate()
	{
		if (!_isInit)
			return;

		_character.rotation = Quaternion.Euler(0, _yRotation, 0);
		//!_camera.transform.rotation = _targetPoint.rotation;
	}
	
	private void LateUpdate()
	{
		if (!_isInit)
			return;
			
		if (!_isWork) //TODO: ???
			return;

		float mouseX = _input.Look.x * Time.fixedDeltaTime * _config.XSensitivity;
		float mouseY = _input.Look.y * Time.fixedDeltaTime * _config.YSensitivity;

		_yRotation += mouseX;
		_xRotation -= mouseY;
		_xRotation = Mathf.Clamp(_xRotation, _config.XClampRotationMin, _config.XClampRotationMax);

		_targetPoint.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
		
		_camera.transform.position = _targetPoint.position;
		_camera.transform.rotation = _targetPoint.rotation; //!!!
	}
	
	public void SetWork(bool status) => _isWork = status; //TODO: ???
	
	// private void FixedUpdate()
	// {
	// 	if (!_isInit)
	// 		return;
	
	// 	float mouseX = _input.Look.x * Time.deltaTime * _config.XSensitivity;
	// 	float mouseY = _input.Look.y * Time.deltaTime * _config.YSensitivity;

	// 	_yRotation += mouseX;
	// 	_xRotation -= mouseY;
	// 	_xRotation = Mathf.Clamp(_xRotation, _config.XClampRotationMin, _config.XClampRotationMax);

	// 	_targetPoint.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
	// 	_character.rotation = Quaternion.Euler(0, _yRotation, 0);
		
	// 	_camera.transform.position = _targetPoint.position;
	// 	_camera.transform.rotation = _targetPoint.rotation;
	// }
//!------------------------------------------------------------------
	
	private void OnDisable() => _tween?.Kill();

	public void SetFOV(float value, float time) 
		=> _tween = _camera.DOFieldOfView(value, time);

	public void ResetFOV(float time) 
		=> _tween = _camera.DOFieldOfView(_config.NormalFOV, time);

	private void UpdatePosition() => transform.position = _targetPoint.position;
}