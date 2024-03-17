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

    public void Initialize(IInputService input, CharacterConfig config, Transform character, Transform point)
    {
        _input = input;
        _config = config.CameraConfig;
        _character = character;
        _targetPoint = point;

        _camera = GetComponent<Camera>();

        _isInit = true;
    }

    private void Update()
    {
        if (_isInit == false)
            return;

        UpdatePosition();
    }

    private void LateUpdate()
    {
        if (_isInit == false)
            return;
            
        float mouseX = _input.Look.x * Time.deltaTime * _config.XSensitivity;
        float mouseY = _input.Look.y * Time.deltaTime * _config.YSensitivity;

        _yRotation += mouseX;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _config.XClampRotationMin, _config.XClampRotationMax);

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _character.rotation = Quaternion.Euler(0, _yRotation, 0);
    }

    public void SetFOV(float value, float time) => _camera.DOFieldOfView(value, time);

    public void ResetFOV(float time) => _camera.DOFieldOfView(_config.NormalFOV, time);

    private void UpdatePosition() => transform.position = _targetPoint.position;
}