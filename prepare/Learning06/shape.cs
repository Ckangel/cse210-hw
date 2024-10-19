// Shape.cs
using System;

public class Shape
{
    public string Color { get; set; }

    public Shape(string color)
    {
        Color = color;
    }

    public virtual double GetArea()
    {
        // This method will be overridden in derived classes
        return 0;
    }
}
