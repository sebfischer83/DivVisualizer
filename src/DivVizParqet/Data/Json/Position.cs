namespace DivVizParqet.Data.Json;

public class Position
{
    public Position(
        int shares,
        double purchasePrice,
        int purchaseValue,
        double currentPrice,
        int currentValue,
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

    public int shares { get; }
    public double purchasePrice { get; }
    public int purchaseValue { get; }
    public double currentPrice { get; }
    public int currentValue { get; }
    public double allocation { get; }
}