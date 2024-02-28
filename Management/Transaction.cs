using System.Reflection;

namespace SupportBank.Management;

public class Transaction
{
    // TRANSACTION PROPERTIES
    public required DateOnly Date { get; set; }
    public required string From { get; set; }
    public required string To { get; set; }
    public required string Narrative { get; set; }
    public required decimal Amount { get; set; }

    // A METHOD THAT RETURNS THE TRANSACTION DETAILS
    public override string ToString() // Overrides the file location for the content
    {
        return $"On {Date} {From} paid £{Amount} to {To} for {Narrative}.";
    }
}