using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Country
{
    public Country(
        string name,
        double share,
        string id
    )
    {
        this.name = name;
        this.share = share;
        this.id = id;
    }

    public string name { get; }
    public double share { get; }
    public string id { get; }
}