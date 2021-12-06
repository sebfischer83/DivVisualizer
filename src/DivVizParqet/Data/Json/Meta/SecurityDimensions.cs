namespace DivVizParqet.Data.Json.Meta;

public class SecurityDimensions
{
    public SecurityDimensions(
        List<Country> countries,
        List<Region> regions,
        List<Industry> industries,
        List<Sector> sectors,
        List<Type> types
    )
    {
        this.countries = countries;
        this.regions = regions;
        this.industries = industries;
        this.sectors = sectors;
        this.types = types;
    }

    public IReadOnlyList<Country> countries { get; }
    public IReadOnlyList<Region> regions { get; }
    public IReadOnlyList<Industry> industries { get; }
    public IReadOnlyList<Sector> sectors { get; }
    public IReadOnlyList<Type> types { get; }
}