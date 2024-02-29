using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour, IPause
{
    private Vector3 _moveDirection;

    private float _xRotation;
    private float _tempYDirection;

    private bool _isPaused;

    private IInput _input;
    private PlayerConfig _config;
    private PauseHandler _pauseHandler;

    private CharacterController _characterController;
    private Camera _camera;

    public bool IsGrounded => _characterController.isGrounded;

    [Inject]
    private void Construct(IInput input, PlayerConfig config, PauseHandler pauseHandler) 
    {
        _input = input;
        _config = config;
        _pauseHandler = pauseHandler;

        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;

        _pauseHandler.Add(this);
    }

    private void Update()
    {
        if (_isPaused)
            return;

        UpdateMovement();
        UpdateJump();
        UpdateGravity();

        Move();
        Look();
    }

    private void UpdateMovement() 
    {
        float speed = _input.IsSprint ? _config.RunSpeed : _config.WalkSpeed;

        _tempYDirection = _moveDirection.y;

        _moveDirection = (transform.forward * speed * _input.Movement.x) + (transform.right * speed * _input.Movement.y);
    }

    private void UpdateJump() 
        => _moveDirection.y = IsJump() ? _config.JumpForce : _tempYDirection;

    private void UpdateGravity() 
    {
        if (IsGrounded == false) 
            _moveDirection.y -= _config.Gravity * Time.deltaTime;
    }

    private void Move() 
        => _characterController.Move(_moveDirection * Time.deltaTime);

    private void Look() 
    {
        _xRotation += -_input.Look.y * _config.LookSensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -_config.LookLimit, _config.LookLimit);

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, _input.Look.x * _config.LookSensitivity, 0);
    }

    private bool IsJump() 
    {
        return /*_input.IsJump &&*/ IsGrounded;
    }

    public void SetPause(bool isPause) => _isPaused = isPause;
}
