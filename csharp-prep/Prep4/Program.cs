using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        List<int> numbers = new List<int>();
        while (true)
        {
            string input = Console.ReadLine();
            int number = int.Parse(input);
            if (number == 0)
            {
                break;
            }
            numbers.Add(number);
        }
        Console.WriteLine("The numbers you entered are:");
        foreach (int num in numbers)
        {

            Console.WriteLine(num);
        }
        Console.WriteLine("The sum of your numbers is:");
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            Console.WriteLine(sum);
        }
        {
            Console.WriteLine("The average of your numbers is:");
            foreach (int num in numbers)
            {
                double average = numbers.Average();
                Console.WriteLine(average);
                break;
            }
        }
        {
            Console.WriteLine("The largest number is:");
            int max = numbers.Max();
            Console.WriteLine(max);
        }
       
    }
}