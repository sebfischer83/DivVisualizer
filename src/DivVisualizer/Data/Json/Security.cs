using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Security
{
    public Security(
        string __id,
        string website,
        string name,
        string type,
        string isin,
        string wkn,
        List<string> keywords,
        CoreData coreData,
        List<Industry> industries,
        List<Country> countries,
        DateTime updatedAt,
        Sources sources,
        string defaultExchange,
        List<Sector> sectors,
        List<Region> regions,
        Tickers tickers,
        string logo
    )
    {
        this._id = __id;
        this.website = website;
        this.name = name;
        this.type = type;
        this.isin = isin;
        this.wkn = wkn;
        this.keywords = keywords;
        this.coreData = coreData;
        this.industries = industries;
        this.countries = countries;
        this.updatedAt = updatedAt;
        this.sources = sources;
        this.defaultExchange = defaultExchange;
        this.sectors = sectors;
        this.regions = regions;
        this.tickers = tickers;
        this.logo = logo;
    }

    public string _id { get; set; }
    public string website { get; }
    public string name { get; }
    public string type { get; }
    public string isin { get; }
    public string wkn { get; }
    public IReadOnlyList<string> keywords { get; }
    public CoreData coreData { get; }
    public IReadOnlyList<Industry> industries { get; }
    public IReadOnlyList<Country> countries { get; }
    public DateTime updatedAt { get; }
    public Sources sources { get; }
    public string defaultExchange { get; }
    public IReadOnlyList<Sector> sectors { get; }
    public IReadOnlyList<Region> regions { get; }
    public Tickers tickers { get; }
    public string logo { get; }
}