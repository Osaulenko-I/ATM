namespace Core.Sessions.UserSessions.UserSessionResult;

public abstract record WithdrawAmountResult
{
    private WithdrawAmountResult() { }
    
    public sealed record Success(Guid SessionId) : WithdrawAmountResult;
    
    public sealed record Failure(string Message) : WithdrawAmountResult;
}