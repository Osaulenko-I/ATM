using Abstractions.Persistence.Repositories;
using Core.Accounts;

namespace Repositories.Repositories;

public sealed class AccountInMemoryRepository : IAccountRepository
{
    private readonly Dictionary<AccountID, Account> _values = [];
    
    public Account Add(Account account)
    {
        account = new Account(new AccountID(_values.Count + 1), account.Amount, account.Pin );
        
        _values.Add(account.AccountID, account);
        
        return account;
    }

    public Account? Query(AccountID id)
    {
        return _values.ContainsKey(id) ? _values[id] : null;
    }
}