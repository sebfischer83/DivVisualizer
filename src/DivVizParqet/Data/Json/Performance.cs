using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Performance
{
    public Performance(
        string since,
        int invested,
        int value,
        int priceAtIntervalStart,
        int valueAtIntervalStart,
        int purchaseValueForInterval,
        int purchaseValue,
        int gainGross,
        int gainNet,
        double returnGross,
        double returnNet,
        int cashflow,
        int taxes,
        int fees,
        double izf,
        Unrealized unrealized,
        Realized realized,
        Dividends dividends,
        int portfolioValue,
        int startingValue
    )
    {
        this.since = since;
        this.invested = invested;
        this.value = value;
        this.priceAtIntervalStart = priceAtIntervalStart;
        this.valueAtIntervalStart = valueAtIntervalStart;
        this.purchaseValueForInterval = purchaseValueForInterval;
        this.purchaseValue = purchaseValue;
        this.gainGross = gainGross;
        this.gainNet = gainNet;
        this.returnGross = returnGross;
        this.returnNet = returnNet;
        this.cashflow = cashflow;
        this.taxes = taxes;
        this.fees = fees;
        this.izf = izf;
        this.unrealized = unrealized;
        this.realized = realized;
        this.dividends = dividends;
        this.portfolioValue = portfolioValue;
        this.startingValue = startingValue;
    }

    public string since { get; }
    public int invested { get; }
    public int value { get; }
    public int priceAtIntervalStart { get; }
    public int valueAtIntervalStart { get; }
    public int purchaseValueForInterval { get; }
    public int purchaseValue { get; }
    public int gainGross { get; }
    public int gainNet { get; }
    public double returnGross { get; }
    public double returnNet { get; }
    public int cashflow { get; }
    public int taxes { get; }
    public int fees { get; }
    public double izf { get; }
    public Unrealized unrealized { get; }
    public Realized realized { get; }
    public Dividends dividends { get; }
    public int portfolioValue { get; }
    public int startingValue { get; }
}