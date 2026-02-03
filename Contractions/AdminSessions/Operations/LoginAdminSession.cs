using Contractions.AdminSessions.models;

namespace Contractions.AdminSessions.Operations;

public static class LoginAdminSession
{
    public readonly record struct Request(string Password);

    public abstract record Response
    {
        private Response() { }
        
        public sealed record Success(AdminSessionDto AdminSessionDto) : Response;

        public sealed record Failure(string Message) : Response;
    }
}