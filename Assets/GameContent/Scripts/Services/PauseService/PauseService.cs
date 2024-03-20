using UnityEngine;

public class PauseService : IPauseService
{
    private const float NormalTimeScale = 1f;

    public void Enable() => Time.timeScale = 0f;

    public void Disable() => Time.timeScale = NormalTimeScale;
}
