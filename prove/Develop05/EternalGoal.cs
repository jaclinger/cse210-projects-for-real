public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public override int RecordEvent()
    {
        return _points;  // never complete, always gives points
    }

    public override string GetStatus()
    {
        return $"[∞] {_name} ({_description})";
    }

    public override string SaveFormat()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}
