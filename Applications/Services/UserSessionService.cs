using Abstractions.Persistence;
using Application.Mapping;
using Contractions.UserSessions;
using Contractions.UserSessions.Operations;
using Core.Accounts;
using Core.Sessions.UserSessions;
using Core.Sessions.UserSessions.UserSessionResult;
using Core.Tranactions;

namespace Application.Services;

internal sealed class UserSessionService : IUserSessionService
{
    private readonly IPersistenceContext _context;

    public UserSessionService(IPersistenceContext context)
    {
        _context = context;
    }
    
    public WithdrawAmount.Response Withdraw(WithdrawAmount.Request request)
    {
        var sessionId = request.SessionId;
        var session = _context.UserSessionRepository.Query(sessionId);
        
        if (session is null)
            return new WithdrawAmount.Response.Failure("Session not found");
        
        var result = session.WithdrawAmount(request.Amount);
        
        if (result is WithdrawAmountResult.Failure failure)
            return new WithdrawAmount.Response.Failure(failure.Message);
        
        _context.TransactionRepository.Add(
            new BankTransaction(session.Account, TransactionType.Withdraw, sessionId, Guid.NewGuid()));
        
        return new WithdrawAmount.Response.Success(session.MapToDto());
    }

    public ReplenishAmount.Response Replenish(ReplenishAmount.Request request)
    {
        var sessionId = request.SessionId;
        var session = _context.UserSessionRepository.Query(sessionId);
        
        if (session is null)
            return new ReplenishAmount.Response.Failure("Session not found");
        
        var result = session.ReplenishAmount(request.Amount);
        
        if (result is ReplenishAmountResult.Failure failure)
            return new ReplenishAmount.Response.Failure(failure.Message);
        
        _context.TransactionRepository.Add(
            new BankTransaction(session.Account, TransactionType.Replenish, sessionId, Guid.NewGuid()));
        
        return new ReplenishAmount.Response.Success(session.MapToDto());
    }

    public ViewAmount.Response ViewBalance(ViewAmount.Request request)
    {
        var sessionId = request.SessionId;
        var session = _context.UserSessionRepository.Query(sessionId);
        
        if (session is null)
            return new ViewAmount.Response.Failure("Session not found");
        
        var result = session.ViewAmount();

        if (result is ViewAmountResult.Failure failure)
            return new ViewAmount.Response.Failure(failure.Message);
        
        return new ViewAmount.Response.Success(session.MapToDto());
    }

    public LoginAccount.Response Login(LoginAccount.Request request)
    {
        var account = _context.AccountRepository.Query(new AccountID(request.AccountId));

        if (account is null)
            return new LoginAccount.Response.Failure("Account not found");
        
        var session = new UserSession(Guid.NewGuid(), account);
        
        _context.UserSessionRepository.Add(session);

        return new LoginAccount.Response.Success(session.MapToDto());
    }

    public ViewHistory.Response ViewHistory(ViewHistory.Request request)
    {
        var sessionId = request.SessionId;
        
        var session = _context.UserSessionRepository.Query(sessionId);
        
        if (session is null)
            return new ViewHistory.Response.Failure("Session not found");
        
        var transaction = _context.TransactionRepository.Query(session.Account.AccountID);
        
        return new ViewHistory.Response.Success(transaction.MapToDto());
    }
}