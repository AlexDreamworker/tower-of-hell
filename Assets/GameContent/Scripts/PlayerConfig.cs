using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float _walkSpeed = 6f;
    [SerializeField] private float _runSpeed = 12f;
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private float _lookSpeed = 2f;
    [SerializeField] private float _gravity = 10f;
    [SerializeField] private float _lookXLimit = 45f;

    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float JumpForce => _jumpForce;
    public float LookSpeed => _lookSpeed;
    public float Gravity => _gravity;
    public float LookXLimit => _lookXLimit;
}
