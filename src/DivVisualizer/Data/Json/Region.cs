using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Region
{
    public Region(
        string id,
        double share
    )
    {
        this.id = id;
        this.share = share;
    }

    public string id { get; }
    public double share { get; }
}