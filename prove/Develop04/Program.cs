using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {name} Activity\n");
        Console.WriteLine(description);
        Console.Write("\nEnter duration (in seconds): ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Pause(3);
    }

    public void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        Pause(2);
        Console.WriteLine($"You completed the {name} Activity for {duration} seconds.");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void Spinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int index = 0;
        while (DateTime.Now < end)
        {
            Console.Write($"\r{symbols[index]}");
            index = (index + 1) % symbols.Length;
            Thread.Sleep(200);
        }
        Console.Write("\r ");
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        name = "Breathing";
        description = "This activity will help you relax by walking you through breathing in and out slowly.";
    }

    public void Run()
    {
        StartMessage();
        DateTime end = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            Console.Write("\n  Breathe in...");
            Pause(3);
            Console.Write("  Breathe out...");
            Pause(3);
        }
        EndMessage();
    }
}

public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        name = "Reflection";
        description = "This activity will help you reflect on times when you have shown strength and resilience.";
    }

    public void Run()
    {
        StartMessage();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        Console.WriteLine("\nReflect on the following questions:\n");
        DateTime end = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            Console.WriteLine(questions[rand.Next(questions.Count)]);
            Spinner(4);
            Console.WriteLine();
        }
        EndMessage();
    }
}

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        name = "Listing";
        description = "This activity will help you reflect on the good things in your life by listing as many as you can.";
    }

    public void Run()
    {
        StartMessage();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        Console.WriteLine("\nGet ready to start listing...");
        Pause(3);

        List<string> items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            Console.Write("Enter an item: ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        EndMessage();
    }
}

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1") new BreathingActivity().Run();
            else if (choice == "2") new ReflectionActivity().Run();
            else if (choice == "3") new ListingActivity().Run();
            else if (choice == "4") break;
            else
            {
                Console.WriteLine("Invalid choice.");
                Thread.Sleep(1000);
            }
        }
    }
}
