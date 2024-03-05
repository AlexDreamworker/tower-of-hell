using UnityEngine;

public class LogService : ILogService
{
    public void Log(string message) 
        => Debug.Log(message);

    public void Log(string message, string color)
        => Debug.Log($"<color={color}>{message}</color>");

    public void LogError(string message) 
        => Debug.LogError(message);

    public void LogWarning(string message) 
        => Debug.LogWarning(message);
}
