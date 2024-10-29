public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name: name, points) { }

    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }

    public override bool IsComplete()
    {
        throw new NotImplementedException();
    }

    public override void RecordEvent()
    {
        NewMethod();
    }

    private void NewMethod()
    {
        NewMethod1();

        void NewMethod1()
        {
            IsComplete = true;
        }
    }
}
