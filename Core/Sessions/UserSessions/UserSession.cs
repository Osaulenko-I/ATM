using Core.Accounts;
using Core.Sessions.UserSessions.UserSessionResult;
using Core.ValueObjects;

namespace Core.Sessions.UserSessions;

public sealed class UserSession
{
    public UserSession(Guid id, Account account)
    {
        SessionId = id;
        Account = account;
    }
    
    public Guid SessionId { get; }
    
    public Account Account { get; }

    public ReplenishAmountResult ReplenishAmount(decimal amount)
    {
        Account.Amount += new Amount(amount);
        return new ReplenishAmountResult.Success(SessionId);
    }

    public ViewAmountResult ViewAmount()
    {
        return new ViewAmountResult.Success(Account.Amount);
    }

    public WithdrawAmountResult WithdrawAmount(decimal amount)
    {
        if (Account.Amount.Value < amount)
            return new WithdrawAmountResult.Failure("not enough amount");

        Account.Amount -= new Amount(amount);
        return new WithdrawAmountResult.Success(SessionId);
    }
}