using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _rand = new Random();

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    protected override void PerformActivity()
    {
        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine("Prompt: " + prompt);
        Console.WriteLine();
        Console.WriteLine("You will have a few seconds to think, then list as many items as you can.");
        Console.WriteLine();

        Countdown(5);

        List<string> entries = new List<string>();
        Stopwatch sw = Stopwatch.StartNew();
        int timeLeft = SecondsRemaining(sw);

        while (sw.Elapsed.TotalSeconds < _durationSeconds)
        {
            int remainingMs = (_durationSeconds - (int)sw.Elapsed.TotalSeconds) * 1000;
            if (remainingMs <= 0) break;

            Console.Write("> ");
            Task<string> readTask = Task.Run(() => Console.ReadLine());
            bool finished = readTask.Wait(remainingMs);
            if (finished)
            {
                string line = readTask.Result;
                if (!string.IsNullOrWhiteSpace(line))
                {
                    entries.Add(line.Trim());
                }
            }
            else
            {
                Console.WriteLine();
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {entries.Count} item(s). Good job!");
    
        if (entries.Count > 0)
        {
            Console.WriteLine("Items:");
            foreach (var e in entries)
            {
                Console.WriteLine("- " + e);
            }
        }
    }
}
