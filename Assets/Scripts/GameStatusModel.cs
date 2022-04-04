public class GameStatusModel
{
    private bool _isStarted;
    private bool _isPaused;

    public bool IsPaused
    {
        get => _isPaused;
        set => _isPaused = value;
    }

    public bool IsStarted
    {
        get => _isStarted;
        set => _isStarted = value;
    }
}