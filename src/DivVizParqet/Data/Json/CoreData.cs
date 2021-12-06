using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class CoreData
{
    public CoreData(
        List<MarketSegment> marketSegments,
        List<Country> countries,
        DateTime createdAt
    )
    {
        this.marketSegments = marketSegments;
        this.countries = countries;
        this.createdAt = createdAt;
    }

    public IReadOnlyList<MarketSegment> marketSegments { get; }
    public IReadOnlyList<Country> countries { get; }
    public DateTime createdAt { get; }
}