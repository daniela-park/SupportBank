namespace SupportBank.Management;
public class Account
{
    // ACCOUNT PROPERTIES
    public required string Name { get; set; }
    public List<Transaction> Transactions { get; } = []; // Starts with an empty list of transaction to be updated later

    // A METHOD THAT RETURNS THE ACCOUNT DETAILS (Name and Transactions)
    public override string ToString() // Overrides the file location address for the content
    {
        return $"NAME: {Name} - BALANCE: £{Transactions.Sum(transaction =>
        {
            if (Name == transaction.From)
            {
                return -transaction.Amount;
            }
            else
            {
                return +transaction.Amount;
            }
        })}";
    }
}