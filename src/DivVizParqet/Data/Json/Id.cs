using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Id
{
    public Id(
        string d,
        string i,
        string e
    )
    {
        this.d = d;
        this.i = i;
        this.e = e;
    }

    public string d { get; }
    public string i { get; }
    public string e { get; }
}