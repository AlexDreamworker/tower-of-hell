using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField, Range(0f, 30f)] private float _walkSpeed = 6f;
    [SerializeField, Range(0f, 30f)] private float _runSpeed = 12f;

    [Space]
    [SerializeField, Range(0f, 30f)] private float _jumpForce = 7f;
    [SerializeField, Range(0f, 30f)] private float _gravity = 10f;

    [Space]
    [SerializeField, Range(0f, 20f)] private float _lookSensitivity = 2f;
    [SerializeField, Range(0f, 100f)] private float _lookLimit = 45f;

    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float JumpForce => _jumpForce;
    public float Gravity => _gravity;
    public float LookSensitivity => _lookSensitivity;
    public float LookLimit => _lookLimit;
}
