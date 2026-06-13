using System;

/*
Exceeded Requirements:
This program tracks how many times each mindfulness activity
has been completed. Users can view activity statistics from
the main menu, helping them monitor their mindfulness practice.
*/

class Program
{
    static void Main(string[] args)
    {
        ActivityTracker tracker = new ActivityTracker();

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. View Activity Statistics");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    tracker.RecordBreathing();
                    break;

                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    tracker.RecordReflection();
                    break;

                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    tracker.RecordListing();
                    break;

                case "4":
                    Console.Clear();
                    tracker.DisplayStatistics();

                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}