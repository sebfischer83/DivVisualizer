namespace DivVizParqet.Data.Json;

public class Holding
{
    public Holding(
        string __id,
        Security security,
        string portfolio,
        string exchange,
        string nickname,
        string user,
        string assetType,
        DateTime earliestActivityDate,
        string currency,
        Position position,
        Quote quote,
        StartQuote startQuote,
        bool currencyAdjusted,
        Performance performance,
        List<FutureDividend> futureDividends,
        string originalCurrency,
        double? fxRateBeginning,
        double? fxRateToday,
        string symbol,
        DateTime? updatedAt,
        DateTime? createdAt
    )
    {
        this._id = __id;
        this.security = security;
        this.portfolio = portfolio;
        this.exchange = exchange;
        this.nickname = nickname;
        this.user = user;
        this.assetType = assetType;
        this.earliestActivityDate = earliestActivityDate;
        this.currency = currency;
        this.position = position;
        this.quote = quote;
        this.startQuote = startQuote;
        this.currencyAdjusted = currencyAdjusted;
        this.performance = performance;
        this.futureDividends = futureDividends;
        this.originalCurrency = originalCurrency;
        this.fxRateBeginning = fxRateBeginning;
        this.fxRateToday = fxRateToday;
        this.symbol = symbol;
        this.updatedAt = updatedAt;
        this.createdAt = createdAt;
    }

    public string _id { get; }
    public Security security { get; }
    public string portfolio { get; }
    public string exchange { get; }
    public string nickname { get; }
    public string user { get; }
    public string assetType { get; }
    public DateTime earliestActivityDate { get; }
    public string currency { get; }
    public Position position { get; }
    public Quote quote { get; }
    public StartQuote startQuote { get; }
    public bool currencyAdjusted { get; }
    public Performance performance { get; }
    public IReadOnlyList<FutureDividend> futureDividends { get; }
    public string originalCurrency { get; }
    public double? fxRateBeginning { get; }
    public double? fxRateToday { get; }
    public string symbol { get; }
    public DateTime? updatedAt { get; }
    public DateTime? createdAt { get; }
}