using System;
// Added a Test of getters and setters 2/5 and 0.4 results at end
public class Fraction
{
    // Private attributes for the numerator and denominator
    private int _numerator;
    private int _denominator;

    // Constructor with no parameters, default to 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor with one parameter for the numerator, default denominator to 1
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Constructor with two parameters for the numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        // Ensure denominator is not zero to avoid divide by zero error
        _denominator = denominator == 0 ? 1 : denominator;
    }

    // Getter and Setter for Numerator
    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    // Getter and Setter for Denominator
    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator != 0)
        {
            _denominator = denominator;
        }
        else
        {
            Console.WriteLine("Denominator cannot be zero. Defaulting to 1.");
            _denominator = 1;
        }
    }

    // Method to get the fraction as a string
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method to get the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
// Testing 

class Program
{
    static void Main(string[] args)
    {
        // Test with the default constructor (1/1)
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString()); // Output: 1/1
        Console.WriteLine(fraction1.GetDecimalValue());   // Output: 1

        // Test with one parameter constructor (5/1)
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString()); // Output: 5/1
        Console.WriteLine(fraction2.GetDecimalValue());   // Output: 5

        // Test with two parameters constructor (3/4)
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString()); // Output: 3/4
        Console.WriteLine(fraction3.GetDecimalValue());   // Output: 0.75

        // Test with two parameters constructor (1/3)
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString()); // Output: 1/3
        Console.WriteLine(fraction4.GetDecimalValue());   // Output: 0.3333333333333333

        // Test getters and setters
        fraction4.SetNumerator(2);
        fraction4.SetDenominator(5);
        Console.WriteLine(fraction4.GetFractionString()); // Output: 2/5
        Console.WriteLine(fraction4.GetDecimalValue());   // Output: 0.4
    }
}