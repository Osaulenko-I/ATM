using Core.ValueObjects;

namespace Core.Sessions.UserSessions.UserSessionResult;

public abstract record ViewAmountResult
{
    private ViewAmountResult() { }

    public sealed record Success(Amount Amount) : ViewAmountResult;
    
    public sealed record Failure(string Message) : ViewAmountResult;
}