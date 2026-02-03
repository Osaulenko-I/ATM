using Abstractions.Persistence;
using Abstractions.Persistence.Repositories;

namespace Repositories.Persistence;

public sealed class PersistenceContextInMemory : IPersistenceContext
{
    public PersistenceContextInMemory(
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository,
        IUserSessionRepository userSessionRepository,
        IAdminSessionRepository adminSessionRepository)
    {
        AccountRepository = accountRepository;
        TransactionRepository = transactionRepository;
        UserSessionRepository = userSessionRepository;
        AdminSessionRepository = adminSessionRepository;
    }

    public IAccountRepository AccountRepository { get; }

    public ITransactionRepository TransactionRepository { get; }

    public IUserSessionRepository UserSessionRepository { get; }

    public IAdminSessionRepository AdminSessionRepository { get; }
}