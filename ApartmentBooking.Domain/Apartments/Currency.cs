namespace ApartmentBooking.Domain.Apartments;

public record Currency
{
    internal static readonly Currency None = new("");

    public static readonly Currency GBP = new("GBP");
    public static readonly Currency EUR = new("EUR");
    public static readonly Currency USD = new("USD");

    private Currency(string code) => Code = code;

    public string Code { get; init; }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException("The currency code is invalid");
    }

    public static readonly IReadOnlyCollection<Currency> All = new[] { GBP, EUR, USD };
}
