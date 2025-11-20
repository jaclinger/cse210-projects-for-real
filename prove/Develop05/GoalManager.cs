using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }

    public int GetScore() { return _score; }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int i = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetStatus()}");
            i++;
        }
        Console.WriteLine();
    }

    public void RecordGoal(int index)
    {
        if (index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Goal g = _goals[index - 1];
        int earned = g.RecordEvent();
        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
    }

    public void Save(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                sw.WriteLine(g.SaveFormat());
            }
        }
        Console.WriteLine("Saved.");
    }

    public void Load(string filename)
    {
        _goals.Clear();
        using (StreamReader sr = new StreamReader(filename))
        {
            _score = int.Parse(sr.ReadLine());

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0];

                if (type == "Simple")
                {
                    var g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (parts[4] == "True") g.RecordEvent(); // force completed
                    _goals.Add(g);
                }
                else if (type == "Eternal")
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (type == "Checklist")
                {
                    var g = new ChecklistGoal(
                        parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[6])
                    );

                    int done = int.Parse(parts[5]);
                    for (int i = 0; i < done; i++)
                        g.RecordEvent();

                    _goals.Add(g);
                }
            }
        }
        Console.WriteLine("Loaded.");
    }

    public int CountGoals() { return _goals.Count; }
}
