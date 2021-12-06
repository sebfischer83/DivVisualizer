namespace DivVizParqet.Data.Json;

public class ColumnPreferences
{
    public ColumnPreferences(
        bool entry,
        bool shares,
        bool value,
        bool performance,
        bool allocation,
        bool realized,
        bool dividends,
        bool startingValue
    )
    {
        this.entry = entry;
        this.shares = shares;
        this.value = value;
        this.performance = performance;
        this.allocation = allocation;
        this.realized = realized;
        this.dividends = dividends;
        this.startingValue = startingValue;
    }

    public bool entry { get; }
    public bool shares { get; }
    public bool value { get; }
    public bool performance { get; }
    public bool allocation { get; }
    public bool realized { get; }
    public bool dividends { get; }
    public bool startingValue { get; }
}