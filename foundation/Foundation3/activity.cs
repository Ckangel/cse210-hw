using System;
using System.Collections.Generic;

// Base class for Activity
abstract class Activity
{
    // Shared attributes
    private DateTime date;
    private int durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        this.date = date;
        this.durationMinutes = durationMinutes;
    }

    public int DurationMinutes
    {
        get { return durationMinutes; }
    }

    // Virtual methods for calculating distance, speed, and pace
    public abstract double GetDistance(); // in miles or km based on activity
    public virtual double GetSpeed()
    {
        return (GetDistance() / durationMinutes) * 60;
    }

    public virtual double GetPace()
    {
        return durationMinutes / GetDistance();
    }

    // Get summary method
    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} - Duration: {durationMinutes} minutes, Distance: {GetDistance():0.00}, Speed: {GetSpeed():0.00}, Pace: {GetPace():0.00}";
    }
}
