using System;
using System.Diagnostics;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _durationSeconds; 
    private static readonly char[] _spinnerChars = new char[] { '|', '/', '-', '\\' };

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    public void Run()
    {
        AskDuration();
        DisplayStartingMessage();
        PrepareToBegin();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected abstract void PerformActivity();

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"*** {_name} ***");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine($"This session will last {_durationSeconds} seconds.");
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done! You have completed the activity.");
        ShowSpinner(3); 
        Console.WriteLine();
        Console.WriteLine($"Completed: {_name} for {_durationSeconds} seconds.");
        Console.WriteLine();
        ShowSpinner(3);
    }

    protected void AskDuration()
    {
        int seconds = 0;
        while (true)
        {
            Console.Write("Enter duration in seconds: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out seconds) && seconds > 0) break;
            Console.WriteLine("Please enter a positive whole number for seconds.");
        }
        _durationSeconds = seconds;
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        Countdown(3);
    }

    protected void ShowSpinner(int seconds)
    {
        Stopwatch sw = Stopwatch.StartNew();
        int idx = 0;
        while (sw.Elapsed.TotalSeconds < seconds)
        {
            Console.Write(_spinnerChars[idx % _spinnerChars.Length]);
            Thread.Sleep(250);
            Console.Write('\b');
            idx++;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected int SecondsRemaining(Stopwatch sw)
    {
        int rem = _durationSeconds - (int)sw.Elapsed.TotalSeconds;
        return rem > 0 ? rem : 0;
    }
}
