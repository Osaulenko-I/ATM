using Abstractions.Persistence.Repositories;

namespace Abstractions.Persistence;

public interface IPersistenceContext
{
    IAccountRepository AccountRepository { get; }
    
    ITransactionRepository TransactionRepository { get; }
    
    IUserSessionRepository UserSessionRepository { get; }
    
    IAdminSessionRepository AdminSessionRepository { get; }
}