namespace Core.Accounts;

public readonly record struct AccountID(long Value)
{
    public static readonly AccountID Default = new(default);
}