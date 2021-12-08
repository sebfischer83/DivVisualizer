using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Industry
{
    public Industry(
        double share,
        string id
    )
    {
        this.share = share;
        this.id = id;
    }

    public double share { get; }
    public string id { get; }
}