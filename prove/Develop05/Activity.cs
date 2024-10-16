// Activity.cs  
using System;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;  // changed from private to protected

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public virtual void RunActivity()
    {
        Console.WriteLine($"Starting {_name}");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner();

        PerformActivity();

        Console.WriteLine($"You have completed {_name} for {_duration} seconds. Well done!");
        ShowSpinner();
    }

    protected virtual void PerformActivity()
    {
        // Default implementation, if needed
    }

    protected void ShowSpinner()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void PauseWithMessage(string message, int seconds)
    {
        Console.WriteLine(message);
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in {i}...");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
 
