using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string desc, int points)
    {
        _name = name;
        _description = desc;
        _points = points;
        _isComplete = false;
    }

    public string GetName() { return _name; }
    public bool IsComplete() { return _isComplete; }

    public abstract int RecordEvent();
    public abstract string GetStatus();    
    public abstract string SaveFormat();
}
