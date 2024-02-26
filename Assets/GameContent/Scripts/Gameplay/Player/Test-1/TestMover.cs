using System.Collections;
using UnityEngine;
using Zenject;
//?using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class TestMover : MonoBehaviour
{
    //[Header("   Settings")]
    public float MoveSpeed = 2.0f;
    public float SprintSpeed = 5.335f;
    [Range(0.0f, 0.3f)] public float RotationSmoothTime = 0.12f;
    public float SpeedChangeRate = 10.0f;
    //public float LookSensitivity = 1f;
    public float JumpHeight = 1.2f;
    public float Gravity = -15.0f;
    public int CurrentJumpsCount = 0;
    public int MaxJumpsCount = 2;

    [Header("   Grounded")]
    public float GroundedOffset = -0.14f;
    public float GroundedRadius = 0.28f;
    public LayerMask GroundLayers;

    // [Header("   Camera")]
    // //public GameObject CinemachineCameraTarget;
    // public float TopClamp = 70.0f;
    // public float BottomClamp = -30.0f;
    // public float CameraAngleOverride = 0.0f;

    private Vector2 _directionMove;
    //private Vector2 _directionLook;
    private bool _isJumpingPressed = false;
    private bool _isSprinting = false;
    //private bool _isCameraFollow = false;
    private bool _isGrounded = true;
    private float _speed;
    //private float _animationBlend;
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;
    //private float _cinemachineTargetYaw;
    //private float _cinemachineTargetPitch;

    //private const float THRESHOLD = 0.01f;

    //* REFERENCES
    //private Animator _animator;
    private CharacterController _controller;
    private IInput _input;
    private Transform _mainCamera;

    private float _xRotation; //!!!
    private bool _isJumpButton; //!!!

    // //* ANIMATION KEYS
    // private static readonly int _speedKey = Animator.StringToHash("Speed");
    // private static readonly int _groundedKey = Animator.StringToHash("Grounded");
    // private static readonly int _jumpKey = Animator.StringToHash("Jump");
    // private static readonly int _freeFallKey = Animator.StringToHash("FreeFall");
    // private static readonly int _motionSpeedKey = Animator.StringToHash("MotionSpeed");

    [Inject]
    private void Construct(IInput input)
    {
        _input = input;

        _mainCamera = Camera.main.transform;

        _controller = GetComponent<CharacterController>();
        //_animator = GetComponent<Animator>();
    }

    // private void Start()
    // {
    //     _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
    // }

    private void Update()
    {
        Updaters(); //!!!

        JumpAndGravity();
        GroundedCheck();
        Move();
    }

    private void LateUpdate()
    {
        //CameraRotation();
        Look();
    }

    private void Look() 
    {
        _xRotation += -_input.Look.y * 2f;
        _xRotation = Mathf.Clamp(_xRotation, -45f, 45f);

        _mainCamera.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, _input.Look.x * 2f, 0);
    }

    // public void ResetAfterPause() 
    // {
    //     SetDirectionMove(Vector2.zero);
    //     SetDirectionLook(Vector2.zero);
    // }

    // public void LoseState() 
    // {
    //     gameObject.SetActive(false);
    // }

    // public void ResetAfterLose() 
    // {
    //     gameObject.SetActive(true);
    // }

    // public void SetPosition(Vector3 position, float yAxis)
    // {
    //     gameObject.transform.position = position;
    //     gameObject.transform.rotation = Quaternion.Euler(0, yAxis, 0);
    // }

#region INPUT READER

    private void Updaters() //!!!!!!! 
    {
        _directionMove = new Vector2(_input.Movement.y, _input.Movement.x);

        _isSprinting = _input.IsSprint;

        _isJumpingPressed = _input.IsJump;
    }

    // public void SetDirectionMove(Vector2 directionMove) => _directionMove = directionMove;
    
    // public void SetDirectionLook(Vector2 directionLook) => _directionLook = directionLook;
    
    // public void SetJump(bool isJumping)
    // {
    //     _isJumpingPressed = isJumping;

    //     if (_isJumpingPressed) 
    //     {
    //         if (!IsGrounded() && CurrentJumpsCount >= MaxJumpsCount)
    //             return;
        
    //         if (CurrentJumpsCount == 0) 
    //             StartCoroutine(WaitForLanding());

    //         Jump();
    //     }
    // }

    // public void SetSprint()
    // {
    //     _isSprinting = !_isSprinting;
    // }

    // public void SetSprintKeyboard(bool isSprinting) 
    // {
    //     _isSprinting = isSprinting;
    // }

    // public void SetCameraFollow(bool isCameraFollow) 
    // {
    //     //Debug.Log($"<color=yellow>CAMERA FOLLOW: {isCameraFollow}</color>");

    //     _isCameraFollow = isCameraFollow;
    // }
    
#endregion

    private void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(
            transform.position.x, 
            transform.position.y - GroundedOffset, 
            transform.position.z 
        );
            
        _isGrounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

        //_animator.SetBool(_groundedKey, _isGrounded);
    }

    // private void CameraRotation()
    // {
    //     if (_directionLook.sqrMagnitude >= THRESHOLD && /*!LockCameraPosition*/ _isCameraFollow) //?????
    //     {
    //         float deltaTimeMultiplier = /*IsCurrentDeviceMouse ?*/ 1.0f /*: Time.deltaTime*/;

    //         _cinemachineTargetYaw += _directionLook.x * deltaTimeMultiplier * LookSensitivity;
    //         _cinemachineTargetPitch += _directionLook.y * deltaTimeMultiplier * LookSensitivity;
    //     }

    //     _cinemachineTargetYaw = Calculator.ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
    //     _cinemachineTargetPitch = Calculator.ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

    //     CinemachineCameraTarget.transform.rotation = Quaternion.Euler(
    //         _cinemachineTargetPitch + CameraAngleOverride,
    //         _cinemachineTargetYaw, 
    //         0.0f
    //     );
    // }

    private void Move()
    {
        float targetSpeed = _isSprinting ? SprintSpeed : MoveSpeed;

        if (_directionMove == Vector2.zero) 
            targetSpeed = 0.0f;

        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = /*_isAnalogMovement ? _directionMove.magnitude :*/ 1f;

        if (currentHorizontalSpeed < targetSpeed - speedOffset ||
            currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                Time.deltaTime * SpeedChangeRate);

            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }

        // _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);

        // if (_animationBlend < 0.01f) 
        //     _animationBlend = 0f;

        Vector3 inputDirection = new Vector3(_directionMove.x, 0.0f, _directionMove.y).normalized;

        if (_directionMove != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                _mainCamera.eulerAngles.y;

            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                RotationSmoothTime);

            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }

        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

        _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
            new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

        //_animator.SetFloat(_speedKey, _animationBlend);
        //_animator.SetFloat(_motionSpeedKey, inputMagnitude);
    }

    private void JumpAndGravity()
    {
        if (_isGrounded)
        {
            CurrentJumpsCount = 0;

            //?TryJump();

            if (_verticalVelocity < 0.0f)
                _verticalVelocity = -2f;
        } 
        else 
        {
            //* ROCKET JUMP!!!
            //* TryJump();

            if (_verticalVelocity < _terminalVelocity)
                _verticalVelocity += Gravity * Time.deltaTime;
        }

        TryJump();
    }

    private void TryJump() 
    {
        if (_isJumpingPressed) 
        {
            if (CurrentJumpsCount < MaxJumpsCount)
                Jump();
            else if (CurrentJumpsCount == 0) 
                StartCoroutine(WaitForLanding());
        }
    }

    private void CheckJumpPressDown()
    {
        if (_isJumpingPressed && _isJumpButton)
            return;
        
        if (_isJumpingPressed == false && _isJumpButton == false)
            return;
        
        _isJumpButton = _isJumpingPressed;
    }

    public void Jump()
    {
        CurrentJumpsCount++;
        _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
    }

    private IEnumerator WaitForLanding() 
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);

        if (_isJumpingPressed) 
            Jump();
    }

    private bool IsGrounded() => _isGrounded;

    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (_isGrounded) 
            Gizmos.color = transparentGreen;
        else 
            Gizmos.color = transparentRed;

        // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        Gizmos.DrawSphere(
            new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z),
            GroundedRadius);
    }
}
