using Core.ValueObjects;

namespace Core.Accounts;

public sealed class Account
{
    public Account(AccountID id, Amount amount, string pin)
    {
        AccountID = id;
        Amount = amount;
        Pin = pin;
    }

    public Amount Amount { get; set; }
    
    public AccountID AccountID { get; }
    
    public string Pin { get; }
}