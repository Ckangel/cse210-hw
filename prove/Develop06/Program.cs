using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestProgram
    {
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            string filePath = "goals.txt"; // File path to save and load goals

            goalManager.LoadGoals(filePath);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== EternalQuest Program ===");
                Console.WriteLine("1. Display Player Info");
                Console.WriteLine("2. List Goal Names");
                Console.WriteLine("3. List Goal Details");
                Console.WriteLine("4. Create a New Goal");
                Console.WriteLine("5. Record an Event for a Goal");
                Console.WriteLine("6. Save Goals");
                Console.WriteLine("7. Load Goals");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        goalManager.DisplayPlayerInfo();
                        break;
                    case "2":
                        goalManager.ListGoalNames();
                        break;
                    case "3":
                        goalManager.ListGoalDetails();
                        break;
                    case "4":
                        CreateGoal(goalManager);
                        break;
                    case "5":
                        RecordGoalEvent(goalManager);
                        break;
                    case "6":
                        goalManager.SaveGoals(filePath);
                        Console.WriteLine("Goals saved successfully.");
                        break;
                    case "7":
                        goalManager.LoadGoals(filePath);
                        Console.WriteLine("Goals loaded successfully.");
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void CreateGoal(GoalManager goalManager)
        {
            Console.WriteLine("Select Goal Type: ");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            Console.Write("Enter Goal Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Goal Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Goal Points: ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal = null;
            switch (choice)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("Enter Target Completions: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Enter Bonus Points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }
            if (newGoal != null)
            {
                goalManager.AddGoal(newGoal);
                Console.WriteLine("Goal created successfully.");
            }
        }

        static void RecordGoalEvent(GoalManager goalManager)
        {
            Console.WriteLine("Select a goal to record an event for:");
            goalManager.ListGoalNames();
            Console.Write("Enter goal number: ");
            int goalIndex;
            if (int.TryParse(Console.ReadLine(), out goalIndex) && goalIndex > 0 && goalIndex <= goalManager._goals.Count)
            {
                goalManager.RecordEvent(goalIndex - 1);
                Console.WriteLine("Event recorded successfully.");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
    }
}