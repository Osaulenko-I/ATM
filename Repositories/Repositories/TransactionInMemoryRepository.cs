using Abstractions.Persistence.Repositories;
using Core.Accounts;
using Core.Tranactions;

namespace Repositories.Repositories;

public sealed class TransactionInMemoryRepository : ITransactionRepository
{
    private readonly List<BankTransaction> _values = [];

    public void Add(BankTransaction bankTransaction)
    {
        _values.Add(bankTransaction);
    }

    public IEnumerable<BankTransaction> Query(AccountID id)
    {
        return _values.Where(x => x.Account.AccountID == id);
    }
}