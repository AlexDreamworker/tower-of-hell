using System;

public class DetectorReceiver
{
    private Level _level;

    public DetectorReceiver(Level level) 
    {
        _level = level;
    }

    public void Triggered(DetectorType type)
    {
        switch(type) 
        {
            case DetectorType.Death:
                _level.OnFailed();
                break;
            case DetectorType.Win:
                _level.OnCompleted();
                break;

            default:
                throw new ArgumentOutOfRangeException($"Unknown trigger type: {type}");
        }
    }
}