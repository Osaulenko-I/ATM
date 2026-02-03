using Contractions.UserSessions.Models;
using Core.Accounts;

namespace Application.Mapping;

public static class AccountMappingExtensions
{
    public static AccountDto MapToDto(this Account account)
        => new AccountDto(account.AccountID.Value, account.Pin, account.Amount.Value);
}