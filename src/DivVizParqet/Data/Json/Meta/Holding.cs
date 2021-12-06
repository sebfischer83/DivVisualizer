namespace DivVizParqet.Data.Json.Meta;

public class Holding
{
    public Holding(
        double share,
        int value,
        string label,
        string isin,
        string id
    )
    {
        this.share = share;
        this.value = value;
        this.label = label;
        this.isin = isin;
        this.id = id;
    }

    public double share { get; }
    public int value { get; }
    public string label { get; }
    public string isin { get; }
    public string id { get; }
}