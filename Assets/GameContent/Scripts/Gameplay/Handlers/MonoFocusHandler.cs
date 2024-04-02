using UnityEngine;
using Zenject;

public class MonoFocusHandler : MonoBehaviour
{
	private Level _level;
	
	[Inject]
	private void Construct(Level level) 
		=> _level = level;
	
	private void OnApplicationFocus(bool hasFocus) => CheckFocus(!hasFocus);

  	private void OnApplicationPause(bool pauseStatus) => CheckFocus(pauseStatus);

	private void CheckFocus(bool isPaused) 
	{
		if (isPaused) 
			_level.OnPaused();
	}
}
