namespace DivVizParqet.Data.Json;

public class Portfolio
{
    public Portfolio(
        string __id,
        string user,
        string name,
        bool @public,
        string selectedDuration,
        ColumnPreferences columnPreferences,
        int activeOverviewTab,
        List<string> perfChartComparisons,
        List<string> perfChartConfig,
        bool noAbsoluteValues,
        string perfStartDate,
        string range,
        DateTime requestedAt,
        DateTime updatedAt,
        string baseCurrency,
        ActivityForm activityForm,
        string ownerTier,
        bool isOwnerPlus,
        string ownerName,
        Performance performance
    )
    {
        this._id = __id;
        this.user = user;
        this.name = name;
        this.@public = @public;
        this.selectedDuration = selectedDuration;
        this.columnPreferences = columnPreferences;
        this.activeOverviewTab = activeOverviewTab;
        this.perfChartComparisons = perfChartComparisons;
        this.perfChartConfig = perfChartConfig;
        this.noAbsoluteValues = noAbsoluteValues;
        this.perfStartDate = perfStartDate;
        this.range = range;
        this.requestedAt = requestedAt;
        this.updatedAt = updatedAt;
        this.baseCurrency = baseCurrency;
        this.activityForm = activityForm;
        this.ownerTier = ownerTier;
        this.isOwnerPlus = isOwnerPlus;
        this.ownerName = ownerName;
        this.performance = performance;
    }

    public string _id { get; }
    public string user { get; }
    public string name { get; }
    public bool @public { get; }
    public string selectedDuration { get; }
    public ColumnPreferences columnPreferences { get; }
    public int activeOverviewTab { get; }
    public IReadOnlyList<string> perfChartComparisons { get; }
    public IReadOnlyList<string> perfChartConfig { get; }
    public bool noAbsoluteValues { get; }
    public string perfStartDate { get; }
    public string range { get; }
    public DateTime requestedAt { get; }
    public DateTime updatedAt { get; }
    public string baseCurrency { get; }
    public ActivityForm activityForm { get; }
    public string ownerTier { get; }
    public bool isOwnerPlus { get; }
    public string ownerName { get; }
    public Performance performance { get; }
}