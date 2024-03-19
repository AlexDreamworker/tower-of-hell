using UnityEngine;

public class Dashing : MonoBehaviour
{
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private PlayerMovement pm;

    //* Dashing
    public float dashForce = 20f;
    public float dashUpwardForce = 0f;
    public float dashDuration = 0.25f;

    //* Camera Effect
    public PlayerCamera cam;
    public float dashFov = 95f;

    //* Cooldown
    public float dashCooldown = 1.5f;
    private float dashCooldownTimer;

    //* Keywards
    public KeyCode dashKey = KeyCode.E;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(dashKey))
            Dash();

        if (dashCooldownTimer > 0)
            dashCooldownTimer -= Time.deltaTime;
    }

    private void Dash() 
    {
        if (dashCooldownTimer > 0)
            return;
        else 
            dashCooldownTimer = dashCooldown;

        pm.isDashing = true;

        cam.DoFov(dashFov);

        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private Vector3 delayedForceToApply;

    private void DelayedDashForce() 
    {
        rb.velocity = Vector3.zero;

        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash() 
    {
        pm.isDashing = false;

        cam.DoFov(85f);
    }
}
