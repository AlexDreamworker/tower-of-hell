using System;

public interface IPauseService
{
    event Action<bool> PauseChanged;

    bool IsPaused { get; }
}
