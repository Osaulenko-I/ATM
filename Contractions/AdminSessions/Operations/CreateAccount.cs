using Contractions.AdminSessions.models;
using Contractions.UserSessions.Models;

namespace Contractions.AdminSessions.Operations;

public static class CreateAccount
{
    public readonly record struct Request(Guid SessionId, string Pin, decimal Amount);

    public abstract record class Response
    {
        private Response() { }

        public sealed record Success(CreatedAccountDto AdminSessionDto) : Response;
        
        public sealed record Failure(string Message) : Response;
    }
}