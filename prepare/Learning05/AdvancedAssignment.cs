// AdvancedAssignment.cs
public class AdvancedAssignment : Assignment
{
    private string _extraDetails;

    public AdvancedAssignment(string studentName, string topic, string extraDetails)
        : base(studentName, topic)
    {
        _extraDetails = extraDetails;
    }

    public string GetFullSummary()
    {
        return GetSummary() + " (" + _extraDetails + ")";
    }
}
