namespace DivVizParqet.Data.Json;

public class FutureDividend
{
    public FutureDividend(
        string type,
        string security,
        double price,
        string currency,
        DateTime date,
        DateTime exDate,
        double exShares
    )
    {
        this.type = type;
        this.security = security;
        this.price = price;
        this.currency = currency;
        this.date = date;
        this.exDate = exDate;
        this.exShares = exShares;
    }

    public string type { get; }
    public string security { get; }
    public double price { get; }
    public string currency { get; }
    public DateTime date { get; }
    public DateTime exDate { get; }
    public double exShares { get; }
}