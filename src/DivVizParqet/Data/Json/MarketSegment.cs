using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class MarketSegment
{
    public MarketSegment(
        double share,
        string name
    )
    {
        this.share = share;
        this.name = name;
    }

    public double share { get; }
    public string name { get; }
}