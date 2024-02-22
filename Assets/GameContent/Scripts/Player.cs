using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private Vector3 _moveDirection;

    private float _xRotation;

    private bool _canMove = true;

    private IInput _input;
    private PlayerConfig _config;

    private CharacterController _characterController;
    private Camera _camera;

    [Inject]
    private void Construct(IInput input, PlayerConfig config) 
    {
        _input = input;
        _config = config;

        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float currentSpeedX = _canMove ? (_input.IsSprint ? _config.RunSpeed : _config.WalkSpeed) * _input.Movement.x : 0f;
        float currentSpeedY = _canMove ? (_input.IsSprint ? _config.RunSpeed : _config.WalkSpeed) * _input.Movement.y : 0f;

        float movementDirectionY = _moveDirection.y;
        _moveDirection = (forward * currentSpeedX) + (right * currentSpeedY);

        if (_input.IsJump && _canMove && _characterController.isGrounded)
            _moveDirection.y = _config.JumpForce;
        else 
            _moveDirection.y = movementDirectionY;

        if (_characterController.isGrounded == false) 
            _moveDirection.y -= _config.Gravity * Time.deltaTime;

        _characterController.Move(_moveDirection * Time.deltaTime);

        if (_canMove)
        {
            _xRotation += -_input.Look.y * _config.LookSpeed;
            _xRotation = Mathf.Clamp(_xRotation, -_config.LookXLimit, _config.LookXLimit);
            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            transform.rotation *= Quaternion.Euler(0, _input.Look.x * _config.LookSpeed, 0);
        }
    }
}
