using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var a = new BreathingActivity();
                a.Run();
                PauseBeforeContinue();
            }
            else if (choice == "2")
            {
                var a = new ReflectionActivity();
                a.Run();
                PauseBeforeContinue();
            }
            else if (choice == "3")
            {
                var a = new ListingActivity();
                a.Run();
                PauseBeforeContinue();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }

    static void PauseBeforeContinue()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }
}
