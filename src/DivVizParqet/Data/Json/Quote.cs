namespace DivVizParqet.Data.Json;

public class Quote
{
    public Quote(
        DateTime cachedAt,
        string date,
        string exchange,
        string isin,
        double price,
        string currency,
        Id __id,
        double? fxRate,
        string originalCurrency,
        bool? currencyAdjusted
    )
    {
        this.cachedAt = cachedAt;
        this.date = date;
        this.exchange = exchange;
        this.isin = isin;
        this.price = price;
        this.currency = currency;
        this._id = __id;
        this.fxRate = fxRate;
        this.originalCurrency = originalCurrency;
        this.currencyAdjusted = currencyAdjusted;
    }

    public DateTime cachedAt { get; }
    public string date { get; }
    public string exchange { get; }
    public string isin { get; }
    public double price { get; }
    public string currency { get; }
    public Id _id { get; }
    public double? fxRate { get; }
    public string originalCurrency { get; }
    public bool? currencyAdjusted { get; }
}