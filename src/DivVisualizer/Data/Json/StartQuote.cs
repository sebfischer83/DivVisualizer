namespace DivVizParqet.Data.Json;

public class StartQuote
{
    public StartQuote(
        Id __id,
        string currency,
        string exchange,
        string date,
        double price,
        string isin,
        DateTime cachedAt,
        double? fxRate,
        string originalCurrency,
        bool? currencyAdjusted
    )
    {
        this._id = __id;
        this.currency = currency;
        this.exchange = exchange;
        this.date = date;
        this.price = price;
        this.isin = isin;
        this.cachedAt = cachedAt;
        this.fxRate = fxRate;
        this.originalCurrency = originalCurrency;
        this.currencyAdjusted = currencyAdjusted;
    }

    public Id _id { get; set; }
    public string currency { get; }
    public string exchange { get; }
    public string date { get; }
    public double price { get; }
    public string isin { get; }
    public DateTime cachedAt { get; }
    public double? fxRate { get; }
    public string originalCurrency { get; }
    public bool? currencyAdjusted { get; }
}