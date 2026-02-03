using Contractions.UserSessions.Models;
using Core.Tranactions;

namespace Application.Mapping;

public static class AtmTransactionTypeMappingExtensions
{
    public static TransactionTypeDto MapToDto(this TransactionType transactionType) => transactionType switch
    {
        TransactionType.Replenish => TransactionTypeDto.Replenish,
        TransactionType.Withdraw => TransactionTypeDto.Withdraw,
        _ => throw new ArgumentOutOfRangeException(nameof(transactionType), transactionType, null)
    };
}