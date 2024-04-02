using System;

public interface IAdsService
{
	event Action FullScreenStarted;
	event Action<bool> FullScreenClosed;

	void ShowFullScreen();
}