public interface ILogService
{
    void Log(string message);
    void LogState(string message, string color);
    void LogError(string message);
    void LogWarning(string message);
}
