using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Activity
{
    public Activity(
        string __id,
        string broker,
        string type,
        string isin,
        string company,
        int shares,
        int tax,
        int fee,
        string date,
        DateTime datetime,
        double price,
        string portfolio,
        string user,
        string holding,
        int amount,
        string currency,
        DateTime createdAt,
        DateTime updatedAt,
        double? buyAmount,
        double? avgHoldingPeriod,
        double? realizedGains
    )
    {
        this._id = __id;
        this.broker = broker;
        this.type = type;
        this.isin = isin;
        this.company = company;
        this.shares = shares;
        this.tax = tax;
        this.fee = fee;
        this.date = date;
        this.datetime = datetime;
        this.price = price;
        this.portfolio = portfolio;
        this.user = user;
        this.holding = holding;
        this.amount = amount;
        this.currency = currency;
        this.createdAt = createdAt;
        this.updatedAt = updatedAt;
        this.buyAmount = buyAmount;
        this.avgHoldingPeriod = avgHoldingPeriod;
        this.realizedGains = realizedGains;
    }

    public string _id { get; }
    public string broker { get; }
    public string type { get; }
    public string isin { get; }
    public string company { get; }
    public int shares { get; }
    public int tax { get; }
    public int fee { get; }
    public string date { get; }
    public DateTime datetime { get; }
    public double price { get; }
    public string portfolio { get; }
    public string user { get; }
    public string holding { get; }
    public int amount { get; }
    public string currency { get; }
    public DateTime createdAt { get; }
    public DateTime updatedAt { get; }
    public double? buyAmount { get; }
    public double? avgHoldingPeriod { get; }
    public double? realizedGains { get; }
}