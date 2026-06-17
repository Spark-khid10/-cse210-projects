using System;

public class LevelGoal : Goal
{
    private int _currentProgress;
    private int _goalTarget;

    public LevelGoal(
        string shortName,
        string description,
        int points,
        int goalTarget)
        : base(shortName, description, points)
    {
        _goalTarget = goalTarget;
        _currentProgress = 0;
    }

    // Constructor used when loading from a file
    public LevelGoal(
        string shortName,
        string description,
        int points,
        int goalTarget,
        int currentProgress)
        : base(shortName, description, points)
    {
        _goalTarget = goalTarget;
        _currentProgress = currentProgress;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This goal has already been completed.");
            return 0;
        }

        _currentProgress++;

        return _points;
    }

    public override bool IsComplete()
    {
        return _currentProgress >= _goalTarget;
    }

    public override string GetDetailsString()
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";

        return $"{checkBox} {_shortName} ({_description}) -- Progress: {_currentProgress}/{_goalTarget}";
    }

    public override string GetStringRepresentation()
    {
        return $"LevelGoal|{_shortName}|{_description}|{_points}|{_goalTarget}|{_currentProgress}";
    }
}