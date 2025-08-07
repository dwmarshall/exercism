public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();
        return a.amount == b.amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b) => !(a == b);

    public override bool Equals(object? obj) => obj is CurrencyAmount c && c == this;

    public override int GetHashCode() => HashCode.Combine(amount, currency);

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();
        return a.amount < b.amount;
    }

    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();
        return a.amount > b.amount;
    }
    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException();
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount a, decimal b)
    {
        return new CurrencyAmount(a.amount * b, a.currency);
    }

    public static CurrencyAmount operator *(decimal a, CurrencyAmount b)
    {
        return new CurrencyAmount(a * b.amount, b.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount a, decimal b)
    {
        return new CurrencyAmount(a.amount / b, a.currency);
    }

    public static implicit operator double(CurrencyAmount a) => (double)a.amount;

    public static implicit operator decimal(CurrencyAmount a) => (decimal)a.amount;
}
