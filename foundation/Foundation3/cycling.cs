
// Derived class for Cycling
class Cycling : Activity
{
    private double distanceKm;

    public Cycling(DateTime date, int durationMinutes, double distanceKm) : base(date, durationMinutes)
    {
        this.distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return distanceKm;
    }
}
