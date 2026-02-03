using Core.Accounts;

namespace Abstractions.Persistence.Repositories;

public interface IAccountRepository
{
    Account Add(Account account);
    
    Account? Query(AccountID id);
}