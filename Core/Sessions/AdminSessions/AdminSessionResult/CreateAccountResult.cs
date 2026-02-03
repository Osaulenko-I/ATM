using Core.Accounts;

namespace Core.Sessions.AdminSessions.AdminSessionResult;

public abstract record CreateAccountResult
{
    private CreateAccountResult() { }

    public sealed record Success(Account Account) : CreateAccountResult;

    public sealed record Failure(string Message) : CreateAccountResult;
}