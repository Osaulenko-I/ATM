namespace Core.Tranactions;

public record struct TransactionId(long Value)
{
    public static readonly TransactionId Default = new(default);
}