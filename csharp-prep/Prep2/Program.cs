using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
    }
}
// Ask the user for their grade percentaged
    Console.Write("Enter your grade percentage: ");
    int percentage = Convert.ToInt32(Console.ReadLine());

    // Variable to hold the letter grade
    string letter = "";

    // Determine the letter grade
    if (percentage >= 90)
    {
        letter = "A"
    }
    // Check for A+
    if (percentage % 10 == 0 && percentage > 90)
    {
        letter += "+";  // A+
    }
    else if (percentage >= 80)
    {
        letter = "B";
    }
    else if (percentage >= 70)
    {
        letter = "C";
    }
    else if (percentage >= 60)
    {
        letter = "D";
    }
    else
    {
        letter = "F";
    }

    // Print the letter grade
    Console.Writeline($"Your letter grade is: {letter}");
    // Determine if the user passed or failed
    if (percentage >= 70)
    {
        Console.WriteLine("Congratulations!  You passed the course.");
    }
    else
    {
        Console.WriteLine("Don't worry, keep trying!  You can do it next time.");
    }
    }
    }