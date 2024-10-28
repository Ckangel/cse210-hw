using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    public List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager() { }

    public void Start()
    {
        // Initialize or load goals here
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {_score}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _goals[goalIndex].RecordEvent();
            if (_goals[goalIndex].IsComplete())
            {
                _score += _goals[goalIndex].Points;
            }
        }
    }

    public void SaveGoals(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                var data = line.Split(',');
                Goal goal = null;
                switch (data[0])
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(data[1], data[2], int.Parse(data[3]));
                        ((SimpleGoal)goal)._isComplete = bool.Parse(data[4]);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(data[1], data[2], int.Parse(data[3]));
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(data[1], data[2], int.Parse(data[3]), int.Parse(data[5]), int.Parse(data[6]));
                        ((ChecklistGoal)goal)._amountCompleted = int.Parse(data[4]);
                        break;
                }
                if (goal != null) _goals.Add(goal);
            }
        }
    }
}