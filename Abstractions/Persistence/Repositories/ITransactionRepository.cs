using Core.Accounts;
using Core.Tranactions;

namespace Abstractions.Persistence.Repositories;

public interface ITransactionRepository
{
    void Add(BankTransaction transaction);
    
    IEnumerable<BankTransaction> Query(AccountID account);
}