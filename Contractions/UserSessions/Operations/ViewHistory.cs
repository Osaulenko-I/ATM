using Contractions.UserSessions.Models;

namespace Contractions.UserSessions.Operations;

public static class ViewHistory
{
    public readonly record struct Request(Guid SessionId);

    public abstract record Response
    {
        private Response() { }
        
        public sealed record Success(HistoryDto HistoryDto) : Response;
        
        public sealed record Failure(string Message) : Response;
    }
}