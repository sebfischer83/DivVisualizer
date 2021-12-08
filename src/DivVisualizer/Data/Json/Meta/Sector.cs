namespace DivVizParqet.Data.Json.Meta;

public class Sector
{
    public Sector(
        string id,
        double share,
        int value,
        string label,
        List<Holding> holdings
    )
    {
        this.id = id;
        this.share = share;
        this.value = value;
        this.label = label;
        this.holdings = holdings;
    }

    public string id { get; }
    public double share { get; }
    public int value { get; }
    public string label { get; }
    public IReadOnlyList<Holding> holdings { get; }
}