using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your score? ");
        string score = Console.ReadLine();
        int number = int.Parse(score);
        string letter;

        if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";
        }
        else if (number >= 70)
        {
            letter = "c";
        }
        else
        {
            letter = "F";
        }   

         int lastDigit = number % 10;
         string sign = "";

         if (lastDigit > 7)
        {
             sign = "+";
        }
         else if (lastDigit < 3)
        {
             sign = "-";
        }
        if (letter == "A" && sign == "+" )
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {letter} {sign}");

        if (number >= 70)
        {
            Console.WriteLine("Congratulations, You passed this course.");
        }
        else
        {
            Console.WriteLine("Keep Your head up, You're getting there. Try again.");
        }

    }
}