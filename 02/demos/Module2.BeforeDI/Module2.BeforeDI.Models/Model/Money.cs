namespace Module2.BeforeDI.Models.Model;

public class Money
{
    public const string USD = "USD";
    public const string EUR = "EUR";
    public const decimal USDToEURRate = 0.9m;
    public string IsoCurrency { get; set; }
    public decimal Amount { get; set; }
    public Money(string isoCurrency, decimal amount)
    {
        IsoCurrency = isoCurrency;
        Amount = amount;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (Money)obj;

        return IsoCurrency == other.IsoCurrency
            && Amount == other.Amount;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IsoCurrency, Amount);
    }

    public override string? ToString()
    {
        return $"{Amount:N2} {IsoCurrency}";
    }
}