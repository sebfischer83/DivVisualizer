namespace DivVizParqet.Data.Json.Meta;

public class AssetDimension
{
    public AssetDimension(
        string id,
        int share,
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
    public int share { get; }
    public int value { get; }
    public string label { get; }
    public IReadOnlyList<Holding> holdings { get; }
}