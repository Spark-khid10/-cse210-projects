using System;

public class ActivityTracker
{
    private int _breathingCount;
    private int _reflectionCount;
    private int _listingCount;

    public void RecordBreathing()
    {
        _breathingCount++;
    }

    public void RecordReflection()
    {
        _reflectionCount++;
    }

    public void RecordListing()
    {
        _listingCount++;
    }

    public void DisplayStatistics()
    {
        Console.WriteLine("Mindfulness Activity Statistics");
        Console.WriteLine();

        Console.WriteLine($"Breathing Activities Completed: {_breathingCount}");
        Console.WriteLine($"Reflection Activities Completed: {_reflectionCount}");
        Console.WriteLine($"Listing Activities Completed: {_listingCount}");
    }
}