using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\nEternal Quest");
            Console.WriteLine($"Score: {manager.GetScore()}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Choose Goal Type:");
                Console.WriteLine("1. Simple");
                Console.WriteLine("2. Eternal");
                Console.WriteLine("3. Checklist");

                int t = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Description: ");
                string desc = Console.ReadLine();

                Console.Write("Points: ");
                int pts = int.Parse(Console.ReadLine());

                if (t == 1)
                {
                    manager.AddGoal(new SimpleGoal(name, desc, pts));
                }
                else if (t == 2)
                {
                    manager.AddGoal(new EternalGoal(name, desc, pts));
                }
                else if (t == 3)
                {
                    Console.Write("Times required: ");
                    int req = int.Parse(Console.ReadLine());

                    Console.Write("Bonus: ");
                    int bonus = int.Parse(Console.ReadLine());

                    manager.AddGoal(new ChecklistGoal(name, desc, pts, req, bonus));
                }
            }
            else if (choice == 2)
            {
                manager.DisplayGoals();
            }
            else if (choice == 3)
            {
                manager.DisplayGoals();
                if (manager.CountGoals() == 0)
                {
                    Console.WriteLine("No goals to record.");
                    continue;
                }

                Console.Write("Which goal did you complete? ");
                int g = int.Parse(Console.ReadLine());
                manager.RecordGoal(g);
            }
            else if (choice == 4)
            {
                Console.Write("Filename: ");
                string f = Console.ReadLine();
                manager.Save(f);
            }
            else if (choice == 5)
            {
                Console.Write("Filename: ");
                string f = Console.ReadLine();
                manager.Load(f);
            }
        }
    }
}
