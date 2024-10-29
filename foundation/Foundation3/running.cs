// Derived class for Running
class Running : Activity
{
    private double distanceMiles;

    public Running(DateTime date, int durationMinutes, double distanceMiles) : base(date, durationMinutes)
    {
        this.distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return distanceMiles;
    }
}
