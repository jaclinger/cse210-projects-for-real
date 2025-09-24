using System;

class Program
{
    static void Main(string[] args)
    {   Random randomGenerator = new Random();
        Console.WriteLine("Would you like to play a game? (yes/no)");
        string response = Console.ReadLine();
        if (response.ToLower() == "yes")
          {
            Console.WriteLine("I'm thinking of a number between 1 and 10. Take a guess");
        }
        else
                {
                    Console.WriteLine("Your loss!");
                    return;
                }
      
        string guess = Console.ReadLine();
        
        int number = randomGenerator.Next(1, 11);
        int userGuess = int.Parse(guess);

        while (userGuess != number)
        {
            if (userGuess > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }
            Console.WriteLine("Guess again!");
            guess = Console.ReadLine();
            userGuess = int.Parse(guess);
        }
        if (userGuess == number)
        {
            Console.WriteLine("You guessed it! You're smarter than you look!");
        }
    }
}