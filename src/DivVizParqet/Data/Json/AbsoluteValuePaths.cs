namespace DivVizParqet.Data.Json;

public class AbsoluteValuePaths
{
    public AbsoluteValuePaths(
        List<string> holdings,
        List<string> portfolio,
        List<string> activities,
        List<string> futureDividends,
        List<string> performance
    )
    {
        this.holdings = holdings;
        this.portfolio = portfolio;
        this.activities = activities;
        this.futureDividends = futureDividends;
        this.performance = performance;
    }

    public IReadOnlyList<string> holdings { get; }
    public IReadOnlyList<string> portfolio { get; }
    public IReadOnlyList<string> activities { get; }
    public IReadOnlyList<string> futureDividends { get; }
    public IReadOnlyList<string> performance { get; }
}