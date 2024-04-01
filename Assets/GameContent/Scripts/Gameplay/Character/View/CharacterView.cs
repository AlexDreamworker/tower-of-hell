using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
	//TODO: Animator.StringToHash()?
	private const string IsIdling = "IsIdling";
	private const string IsWalking = "IsWalking";
	private const string IsRunning = "IsRunning";
	private const string IsDancing = "IsDancing";
	
	private Animator _animator;

	public void Initialize()
	{
		_animator = GetComponent<Animator>();

		StartDancing();
	}

	public void StartWork() => StopDancing();

	public void StartIdling() => _animator.SetBool(IsIdling, true);
	public void StopIdling() => _animator.SetBool(IsIdling, false);

	public void StartWalking() => _animator.SetBool(IsWalking, true);
	public void StopWalking() => _animator.SetBool(IsWalking, false);

	public void StartRunning() => _animator.SetBool(IsRunning, true);
	public void StopRunning() => _animator.SetBool(IsRunning, false);

	private void StartDancing() => _animator.SetBool(IsDancing, true);
	private void StopDancing() => _animator.SetBool(IsDancing, false);
}