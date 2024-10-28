    // EternalGoal subclass
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override void RecordEvent()
        {
            // No completion, just adds points
        }

        public override bool IsComplete() => false;

        public override string GetStringRepresentation() =>
            $"EternalGoal,{_shortName},{_description},{_points}";
    }
