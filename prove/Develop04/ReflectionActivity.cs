using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _rand = new Random();

    public ReflectionActivity()
        : base("Reflection Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    protected override void PerformActivity()
    {
        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine("Prompt: " + prompt);
        Console.WriteLine();
        Console.WriteLine("When you are ready, reflect on the following questions.");
        Console.WriteLine();

        Stopwatch sw = Stopwatch.StartNew();

        while (sw.Elapsed.TotalSeconds < _durationSeconds)
        {
            string q = _questions[_rand.Next(_questions.Count)];
            Console.WriteLine("- " + q);
            int wait = Math.Min(4, SecondsRemaining(sw));
            if (wait <= 0) break;
            ShowSpinner(wait);
            Console.WriteLine();
        }
    }
}
