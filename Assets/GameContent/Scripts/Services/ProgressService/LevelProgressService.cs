using GamePush;
using UnityEngine;

public class LevelProgressService : IProgressService //TODO: rename?
{
	public void Save(string key, int value)
	{
#if UNITY_EDITOR
		PlayerPrefs.SetInt(key, value); 
		PlayerPrefs.Save();
#else
		GP_Player.Set(key, value);
		GP_Player.Sync();
#endif
	}

	public int Load(string key)
	{
		int value = 0;
		
#if UNITY_EDITOR
		value = PlayerPrefs.GetInt(key, 0);
#else
		value = GP_Player.GetInt(key);
#endif
		return value;
	}
}
