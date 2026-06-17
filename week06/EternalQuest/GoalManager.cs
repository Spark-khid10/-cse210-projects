using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Level Goal");
        Console.WriteLine();

        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("How many points is it worth? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("How many times does this goal need to be completed? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for completing it? ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus));
                break;

            case "4":
                Console.Write("What is the target progress amount? ");
                int goalTarget = int.Parse(Console.ReadLine());

                _goals.Add(
                    new LevelGoal(
                        name,
                        description,
                        points,
                        goalTarget));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("Goal created successfully!");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void DisplayGoals()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
        }
        else
        {
            Console.WriteLine("Your Goals:");

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("The Goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        Console.WriteLine();
        Console.Write("Which goal did you accomplish? ");

        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            Console.ReadLine();
            return;
        }

        Goal selectedGoal = _goals[goalNumber - 1];

        int pointsEarned = selectedGoal.RecordEvent();

        _score += pointsEarned;

        Console.WriteLine();
        Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");
        Console.WriteLine($"You now have {_score} points.");

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.Clear();

        Console.Write("What is the filename? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void LoadGoals()
    {
        Console.Clear();

        Console.Write("What is the filename? ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            Console.ReadLine();
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(fileName);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            string goalType = parts[0];

            switch (goalType)
            {
                case "SimpleGoal":
                    _goals.Add(
                        new SimpleGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            bool.Parse(parts[4])));
                    break;

                case "EternalGoal":
                    _goals.Add(
                        new EternalGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3])));
                    break;

                case "ChecklistGoal":
                    _goals.Add(
                        new ChecklistGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            int.Parse(parts[4]),
                            int.Parse(parts[5]),
                            int.Parse(parts[6])));
                    break;

                case "LevelGoal":
                    _goals.Add(
                        new LevelGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            int.Parse(parts[4]),
                            int.Parse(parts[5])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}