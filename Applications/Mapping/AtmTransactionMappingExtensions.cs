using Contractions.UserSessions.Models;
using Core.Tranactions;

namespace Application.Mapping;

public static class AtmTransactionMappingExtensions
{
    public static AtmTransactionDto MapToDto(this BankTransaction transaction)
        => new AtmTransactionDto(transaction.TransactionId, transaction.TransactionType.MapToDto(), transaction.SessionId);
}