using System;
using GamePush;

public class GamePushAdsService : IAdsService
{
	public event Action FullScreenStarted;
	public event Action<bool> FullScreenClosed;

	public void ShowFullScreen() => GP_Ads.ShowFullscreen(OnFullScreenStarted, OnFullScreenClosed);
	
	private void OnFullScreenStarted() => FullScreenStarted?.Invoke();
	private void OnFullScreenClosed(bool success) => FullScreenClosed?.Invoke(success);
}
