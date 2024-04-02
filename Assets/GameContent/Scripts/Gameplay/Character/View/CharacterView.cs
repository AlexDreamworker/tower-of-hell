using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
	private readonly int IsIdlingKey = Animator.StringToHash("IsIdling");
	private readonly int IsWalkingKey = Animator.StringToHash("IsWalking");
	private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
	private readonly int IsDancingKey = Animator.StringToHash("IsDancing");
	
	private Animator _animator;

	public void Initialize()
	{
		_animator = GetComponent<Animator>();

		StartDancing();
	}

	public void StartWork() => StopDancing();

	public void StartIdling() => _animator.SetBool(IsIdlingKey, true);
	public void StopIdling() => _animator.SetBool(IsIdlingKey, false);

	public void StartWalking() => _animator.SetBool(IsWalkingKey, true);
	public void StopWalking() => _animator.SetBool(IsWalkingKey, false);

	public void StartRunning() => _animator.SetBool(IsRunningKey, true);
	public void StopRunning() => _animator.SetBool(IsRunningKey, false);

	private void StartDancing() => _animator.SetBool(IsDancingKey, true);
	private void StopDancing() => _animator.SetBool(IsDancingKey, false);
}