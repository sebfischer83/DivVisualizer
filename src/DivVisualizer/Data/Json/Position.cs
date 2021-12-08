namespace DivVizParqet.Data.Json;

public class Position
{
    public Position(
        double shares,
        double purchasePrice,
        double purchaseValue,
        double currentPrice,
        double currentValue,
        double allocation
    )
    {
        this.shares = shares;
        this.purchasePrice = purchasePrice;
        this.purchaseValue = purchaseValue;
        this.currentPrice = currentPrice;
        this.currentValue = currentValue;
        this.allocation = allocation;
    }

    public double shares { get; }
    public double purchasePrice { get; }
    public double purchaseValue { get; }
    public double currentPrice { get; }
    public double currentValue { get; }
    public double allocation { get; }
}