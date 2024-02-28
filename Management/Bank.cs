namespace SupportBank.Management;
public class Bank
{
    // PROPERTIES OF CLASS: HashSet<Account>
    private readonly HashSet<Account> _accounts; // <Account> is the datatype for the HashSet

    // A CONSTRUCTOR TO CREATE ACCOUNTS
    public Bank(IEnumerable<Transaction> transactions)
    {
        var accounts = new HashSet<Account>();
        foreach (var transaction in transactions)
        {
            if (!accounts.Any(account => account.Name == transaction.From)) // If there are not any accounts where name = transaction.from 
            {
                accounts.Add(new Account // Create a new account
                {
                    Name = transaction.From,
                });
            }
            if (!accounts.Any(account => account.Name == transaction.To))
            {
                accounts.Add(new Account
                {
                    Name = transaction.To,
                });
            }
            var fromAccount = accounts.Single(account => account.Name == transaction.From);
            fromAccount.Transactions.Add(transaction);
            var toAccount = accounts.Single(account => account.Name == transaction.To);
            toAccount.Transactions.Add(transaction);            
        }
        _accounts = accounts;
    }

    // A METHOD TO DISPLAY ALL THE TRANSACTIONS
    public void ListAll()
    {
        foreach (var account in _accounts)
        {
            Console.WriteLine(account);
        }
    }

    // A METHOD TO DISPLAY THE TRANSACTIONS FROM A SPECIFIC ACCOUNT
    public void ListAccount(string name) // Pass the parameter "name"
    {
        var account = _accounts.Single(account => account.Name == name); // Selects the single account where the name matches
        foreach (var transaction in account.Transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}