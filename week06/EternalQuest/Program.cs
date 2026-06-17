using System;

/*
Exceeded Requirements:
This program includes an additional goal type called LevelGoal.
A LevelGoal allows users to make incremental progress toward a large goal.
This provides another layer of gamification and progress tracking beyond
the required SimpleGoal, EternalGoal, and ChecklistGoal types.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine($"You have {manager.GetScore()} points.");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("7. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    manager.SaveGoals();
                    break;

                case "4":
                    manager.LoadGoals();
                    break;

                case "5":
                    manager.RecordEvent();
                    break;

                case "6":
                Console.WriteLine($"You currently have {manager.GetScore()} points.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                break;

                case "7":
                running = false;
                break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}