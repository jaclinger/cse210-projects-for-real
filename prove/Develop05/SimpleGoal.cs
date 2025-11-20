public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        string mark = _isComplete ? "[X]" : "[ ]";
        return $"{mark} {_name} ({_description})";
    }

    public override string SaveFormat()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
    }
}
