using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //* Movement
    [Space]
    private float moveSpeed; //* private =D

    public float walkSpeed = 7f;
    public float sprintSpeed = 10f;
    public float dashSpeed = 20f;

    public float groundDrag = 5f;

    //* Dashing
    public bool isDashing;

    //* Keybindings
    [Space]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.C;

    //* Ground Check
    [Space]
    public float playerHeight = 2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    //* Slope Handling
    public float maxSlopeAngle = 40f;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    //* Jump
    [Space]
    public float jumpForce = 10f;
    public float jumpCooldown = 0.25f;
    public float airMultiplier = 0.4f;
    public bool _isReadyToJump = true;

    //* Crouching
    public float crouchSpeed = 3.5f;
    public float crouchYScale = 0.5f;
    private float startYScale; //* private =D
    private bool headObstacle; //!!!!!!!!!!!!!!

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    public MovementState state;

    public enum MovementState 
    {
        walking,
        sprinting,
        crouching,
        dashing,
        air
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        _isReadyToJump = true;

        startYScale = transform.localScale.y;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, groundLayer);

        MyInput();
        SpeedControl(); //TODO: or in FixedUpdate?
        StateHandler();

        //if (isGrounded)
        if (state == MovementState.walking || state == MovementState.sprinting || state == MovementState.crouching)
            rb.drag = groundDrag;
        else 
            rb.drag = 0;

//!>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //! Head obstacle check
        headObstacle = Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.up, out RaycastHit hitHeadObstacle, playerHeight * 0.5f);
        Vector3 lineStartHeadObstacle = transform.position + Vector3.up * 0.5f;
        Vector3 lineEndHeadObstacle = headObstacle ? hitHeadObstacle.point : transform.position + Vector3.up * (playerHeight * 0.5f);
        Debug.DrawLine(lineStartHeadObstacle, lineEndHeadObstacle, headObstacle ? Color.red : Color.green);
//!>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    }

    private void FixedUpdate()
    {
        MovePlayer();

        //* my custom gravity
        rb.AddForce(Vector3.down * 10f, ForceMode.Force);
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && _isReadyToJump && isGrounded)
        {
            _isReadyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        //* CROUCHING
        // if (Input.GetKeyDown(crouchKey))
        // {
        //     transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        //     rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        // }

        // if (Input.GetKeyUp(crouchKey)) 
        // {
        //     transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        // }
        
//!>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // //! CROUCHING WITH HEAD RAYCAST
        // if (Input.GetKey(crouchKey) && isGrounded) //TODO: really need isGrounded?
        // {
        //     transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        //     rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); //TODO: this stopped moving?
        // } 
        // else 
        // {
        //     if (!headObstacle)
        //         transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        // }

        //! CROUCHING WITH HEAD RAYCAST
        if (Input.GetKeyDown(crouchKey) && isGrounded) //TODO: really need isGrounded?
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); //TODO: this stopped moving?
        } 

        if (Input.GetKeyUp(crouchKey))
        {
            if (!headObstacle)
                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
//!>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    }

    private void StateHandler() 
    {
        if (isDashing) 
        {
            state = MovementState.dashing;
            moveSpeed = dashSpeed;
        }

        //TODO: crouch need roof detector!
        else if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }

        else if (isGrounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        else if (isGrounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        else 
        {
            state = MovementState.air;
        }
    }

    private void MovePlayer() 
    {
        if (state == MovementState.dashing)
            return;

        //* calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //* on slope
        if (OnSlope() && exitingSlope == false) 
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        //* on ground
        else if (isGrounded) //! else???
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //* on air
        else if (!isGrounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        //* turn gravity off while on slope
        rb.useGravity = !OnSlope(); 
    }

    private void SpeedControl() 
    {
        //* limited speed on slope
        if (OnSlope() && exitingSlope == false)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }

        //* limited speed on ground or in air
        else 
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVelocity.magnitude > moveSpeed) 
            {
                Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
            }
        }
    }

    private void Jump()
    {
        exitingSlope = true;

        //* reset Y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        _isReadyToJump = true;

        exitingSlope = false;
    }

    private bool OnSlope() 
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f)) 
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection() 
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    //! CROUCH TEST
    // if (Input.GetKeyDown(crouchKey))
    //     {
    //         transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
    //         rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

    //         isCrouched = true;
    //     }


    //     // new stop crouch
    //     if (!Input.GetKey(crouchKey) && !Physics.CapsuleCast(new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z), 0.5f, Vector3.up, 1f))
    //     {
    //         transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
    //         isCrouched = false;
    //     }
}
