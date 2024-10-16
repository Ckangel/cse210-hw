// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Roberto Rodrigues", "Fractions");
        
        Console.WriteLine(assignment.GetSummary());
       
        AdvancedAssignment advAssignment = new AdvancedAssignment("Jane Doe", "Math", "Chapter 1-3 Review");
        Console.WriteLine(advAssignment.GetFullSummary());
    }
}
