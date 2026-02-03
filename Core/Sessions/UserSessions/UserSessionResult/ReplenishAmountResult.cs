namespace Core.Sessions.UserSessions.UserSessionResult;

public abstract record ReplenishAmountResult
{
    private ReplenishAmountResult() { }

    public sealed record Success(Guid SessionId) : ReplenishAmountResult;
    
    public sealed record Failure(string Message) : ReplenishAmountResult;
}