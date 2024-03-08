using UnityEngine;
using Zenject;

[RequireComponent(typeof(Camera))]
public class CharacterCamera : MonoBehaviour
{
    private IInputService _input;
    private CharacterCameraConfig _config;
    private MovementStateMachineData _data;
    private Transform _character;
    private Transform _targetPoint;
    private Camera _camera;

    private float _xRotation;
    private float _yRotation;

    private bool _isInit;

    [Inject]
    private void Construct(IInputService input, CharacterConfig config, MovementStateMachineData data) 
    {
        _input = input;
        _config = config.CameraConfig;
        _data = data;

        _camera = GetComponent<Camera>();
    }

    public void Initialize(Transform character, Transform point)
    {
        _character = character;
        _targetPoint = point;

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

    private void UpdatePosition() => transform.position = _targetPoint.position;

    //TODO: Implement camera effects without DOTween.

    // public void DoFov(float endValue) 
    // {
    //     GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
    // }
}