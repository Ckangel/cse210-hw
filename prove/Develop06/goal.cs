    // Base Goal class
    public abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        // Property to accress points
        public int Points => _points;

        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public abstract void RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetStringRepresentation();
        public virtual string GetDetailsString() => $"{_shortName}: {_description} - {_points} points";
    }

