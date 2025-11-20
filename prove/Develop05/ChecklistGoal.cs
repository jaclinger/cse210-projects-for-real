public class ChecklistGoal : Goal
{
    private int _requiredTimes;
    private int _timesDone;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int required, int bonus)
        : base(name, desc, points)
    {
        _requiredTimes = required;
        _bonus = bonus;
        _timesDone = 0;
    }

    public override int RecordEvent()
    {
        if (_isComplete) return 0;

        _timesDone++;

        if (_timesDone >= _requiredTimes)
        {
            _isComplete = true;
            return _points + _bonus;
        }

        return _points;
    }

    public override string GetStatus()
    {
        string mark = _isComplete ? "[X]" : "[ ]";
        return $"{mark} {_name} ({_description}) — Completed {_timesDone}/{_requiredTimes}";
    }

    public override string SaveFormat()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_requiredTimes}|{_timesDone}|{_bonus}|{_isComplete}";
    }
}
