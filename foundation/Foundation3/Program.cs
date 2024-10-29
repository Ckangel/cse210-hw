using System;
// Program class
class Program
{
    static void Main()
    {
        // Create activities
        var activities = new List<Activity>
        {
            new Running(DateTime.Now, 30, 3.1), // 3.1 miles
            new Cycling(DateTime.Now, 45, 15.0), // 15 km
            new Swimming(DateTime.Now, 25, 40)   // 40 laps
        };

        // Display summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}