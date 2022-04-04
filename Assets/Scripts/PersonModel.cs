public class PersonModel
{
    private int _health = 100;
    private int _level = 1;
    private int _score;

    public int Health
    {
        get => _health;
        set => _health = value;
    }

    public int Level
    {
        get => _level;
        set => _level = value;
    }

    public int Score
    {
        get => _score;
        set => _score = value;
    }
}
