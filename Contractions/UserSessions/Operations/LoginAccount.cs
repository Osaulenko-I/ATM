using Contractions.UserSessions.Models;

namespace Contractions.UserSessions.Operations;

public static class LoginAccount
{
    public record struct Request(long AccountId, string Password);

    public abstract record Response
    {
        private Response() { }
        
        public sealed record Success(UserSessionDto UserSessionDto) : Response;
        
        public sealed record Failure(string Massage) : Response;
    }
}