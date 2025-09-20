using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What grade percentage did you get in class?");
        string gradeInput = Console.ReadLine();
        int gradePercentage = int.Parse(gradeInput);
        string grade = "";

        if (gradePercentage >= 90)
        {
            grade = "A";
        }
        else if (gradePercentage >= 80)
        {
            grade = "B";
        }
        else if (gradePercentage >= 70)
        {
            grade = "C";
        }
        else if (gradePercentage >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }
        Console.WriteLine($"Your grade is: {grade}");   
    }
}