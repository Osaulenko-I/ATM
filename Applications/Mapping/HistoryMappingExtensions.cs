using Contractions.UserSessions.Models;
using Core.Tranactions;

namespace Application.Mapping;

public static class HistoryMappingExtensions
{
    public static HistoryDto MapToDto(this IEnumerable<BankTransaction> transaction)
        => new HistoryDto(transaction.Select(x => x.MapToDto()).ToList());
}