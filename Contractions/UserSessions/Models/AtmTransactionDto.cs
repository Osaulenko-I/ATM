using System.Transactions;

namespace Contractions.UserSessions.Models;

public sealed record AtmTransactionDto(Guid TransactionId, TransactionTypeDto Transaction, Guid SessionId);