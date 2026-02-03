using Core.Accounts;

namespace Core.Tranactions;

public sealed class BankTransaction
{
    public Guid TransactionId { get; }
    
    public Account Account { get; }
    
    public TransactionType TransactionType { get; }
    
    public Guid SessionId { get; }

    public BankTransaction(Account account, TransactionType transactionType, Guid sessionId, Guid transactionId)
    {
        Account = account;
        TransactionType = transactionType;
        SessionId = sessionId;
        TransactionId = transactionId;
    }
}