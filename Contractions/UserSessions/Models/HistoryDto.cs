namespace Contractions.UserSessions.Models;

public sealed record HistoryDto(IReadOnlyCollection<AtmTransactionDto> Transactions);