using Core.Accounts;
using Core.Sessions.AdminSessions.AdminSessionResult;
using Core.ValueObjects;

namespace Core.Sessions.AdminSessions;

public sealed class AdminSession
{
    public AdminSession(Guid sessionId)
    {
        SessionId = sessionId;
    }

    public static string Password { get; set; } = "admin";
    
    public Guid SessionId { get; }

    public CreateAccountResult CreateAccount(string pin, decimal amount)
    {
        if (amount < 0)
            return new CreateAccountResult.Failure("Amount cannot be negative");

        return new CreateAccountResult.Success(new Account(AccountID.Default, new Amount(amount), pin));
    }
}