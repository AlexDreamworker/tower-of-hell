using DG.Tweening;
using UnityEngine;
using Zenject;

public class CharacterCamera : MonoBehaviour
{
    private Transform _character;
    private IInputService _input;
    private Transform _targetPoint;
    private CharacterCameraConfig _config;

    private float _xRotation;
    private float _yRotation;

    private bool _isInit;

    [Inject]
    private void Construct(IInputService input, CharacterConfig config) 
    {
        _input = input;
        _config = config.CameraConfig;
    }

    public void Initialization(Transform character, Transform point)
    {
        _character = character;
        _targetPoint = point;

        _isInit = true;
    }

    private void Update()
    {
        if (_isInit == false)
            return;

        transform.position = _targetPoint.position;
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

    //TODO: Implement camera effects without DOTween.

    // public void DoFov(float endValue) 
    // {
    //     GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
    // }
}