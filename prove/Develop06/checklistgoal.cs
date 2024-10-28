    // ChecklistGoal subclass
    public class ChecklistGoal : Goal
    {
        public int _amountCompleted;
        private int _target;
        private int _bonus;

    public int Bonus { get => _bonus; set => _bonus = value; }

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0;
        }

        public override void RecordEvent()
        {
            _amountCompleted++;
        }

        public override bool IsComplete() => _amountCompleted >= _target;

        public override string GetDetailsString() =>
            $"{_shortName}: {_description} - {_points} points each, {_bonus} bonus after {_target} completions";

        public override string GetStringRepresentation() =>
            $"ChecklistGoal,{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }
