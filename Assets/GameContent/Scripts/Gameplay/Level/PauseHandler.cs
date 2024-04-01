using UnityEngine;
using Zenject;

//TODO: Move to services? Remove from SceneContext!
public class PauseHandler : MonoBehaviour
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
