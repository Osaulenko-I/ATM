namespace Core.ValueObjects;

public sealed record Amount
{
    public Amount(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Amount must be non-negative");

        Value = value;
    }
    public decimal Value { get; }

    public static Amount operator +(Amount a, Amount b) => new(a.Value + b.Value);
    public static Amount operator -(Amount a, Amount b) => new(a.Value - b.Value);
}