using Abstractions.Persistence;
using Application.Mapping;
using Contractions.AdminSessions;
using Contractions.AdminSessions.Operations;
using Core.Sessions.AdminSessions;
using Core.Sessions.AdminSessions.AdminSessionResult;

namespace Application.Services;

internal sealed class AdminSessionService : IAdminSessionService
{
    private readonly IPersistenceContext _context;

    public AdminSessionService(IPersistenceContext context)
    {
        _context = context;
    }
    
    public CreateAccount.Response Create(CreateAccount.Request request)
    {
        var sessionId = request.SessionId;
        var session = _context.AdminSessionRepository.Query(sessionId);
        
        if (session is null)
            return new CreateAccount.Response.Failure("Session not found");

        var result = session.CreateAccount(request.Pin, request.Amount);
        
        if (result is CreateAccountResult.Failure failure)
            return new CreateAccount.Response.Failure(failure.Message);
        
        if (result is CreateAccountResult.Success success)
        {
            var account = _context.AccountRepository.Add(success.Account);
            return new CreateAccount.Response.Success(session.MapToDto(account));
        }
        
        return new CreateAccount.Response.Failure("Bad request");
    }

    public LoginAdminSession.Response Login(LoginAdminSession.Request request)
    {
        if (AdminSession.Password != request.Password) 
            return new LoginAdminSession.Response.Failure("Wrong password");
        
        var adminSession = new AdminSession(Guid.NewGuid());
        _context.AdminSessionRepository.Add(adminSession);
        
        return new LoginAdminSession.Response.Success(adminSession.MapToDto());
    }
}