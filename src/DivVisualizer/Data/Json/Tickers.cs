using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Tickers
{
    public Tickers(
        string frankfurt,
        string xetra,
        string stuttgart,
        string munich,
        string berlin,
        string nyse,
        string nasdaq
    )
    {
        this.frankfurt = frankfurt;
        this.xetra = xetra;
        this.stuttgart = stuttgart;
        this.munich = munich;
        this.berlin = berlin;
        this.nyse = nyse;
        this.nasdaq = nasdaq;
    }

    public string frankfurt { get; }
    public string xetra { get; }
    public string stuttgart { get; }
    public string munich { get; }
    public string berlin { get; }
    public string nyse { get; }
    public string nasdaq { get; }
}