using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private const string IsIdling = "IsIdling";
    private const string IsWalking = "IsWalking";
    private const string IsRunning = "IsRunning";
    
    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartWalking() => _animator.SetBool(IsWalking, true);
    public void StopWalking() => _animator.SetBool(IsWalking, false);

    public void StartRunning() => _animator.SetBool(IsRunning, true);
    public void StopRunning() => _animator.SetBool(IsRunning, false);
}