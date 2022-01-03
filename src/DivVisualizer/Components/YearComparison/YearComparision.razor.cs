using DivVisualizer.Data.App;
using DivVisualizer.Services;
using DivVisualizer.Store.App;
using Fluxor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagEChartsBlazor.Configuration;
using TagEChartsBlazor.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Globalization;
using AntDesign;
using Blazored.LocalStorage;

namespace DivVisualizer.Components.YearComparison
{
    public partial class YearComparision : Fluxor.Blazor.Web.Components.FluxorComponent
    {
        [Inject]
        internal IState<AppState> AppState { get; set; } = null!;

        [Inject]
        internal IDepotService JsonDepotService { get; set; } = null!;

        [Inject]
        internal EChartsHelper EchartHelper { get; set; } = null!;

        [Inject]
        internal JsNetBridgeService JsNetBridgeService { get; set; } = null!;

        [Inject]
        internal NavigationManager NavManager { get; set; } = null!;

        [Inject]
        internal ILocalStorageService LocalStorageService { get; set; } = null!;

        internal AntDesign.Table<DividendSumsYear> DivChangesPerYearTable { get; set; } = null!;

        internal ECharts? OverviewChart;

        internal bool InitSuccess = false;

        internal object[] MonthlyData;

        internal object[] MonthlyComparisionData;

        internal List<DividendSumsYear> DividendSumsYears { get; set; } = null!;

        internal string[] Years { get; set; } = null!;

        internal double[] SumValuesPerYear { get; set; } = null!;

        internal Dictionary<string, string> XAxisDescriptions { get; set; } = null!;

        internal int SelectedYear = 0;
        internal int MinimumYear = 0;

        public YearComparision()
        {
            MonthlyData = new object[0];
            MonthlyComparisionData = new object[0];
        }
        
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender)
                return;

            var meta = (await JsonDepotService.GetDatabaseOverviewAsync());
            MinimumYear = meta.EarliestDate.Year;
            SelectedYear = MinimumYear;

            if (await LocalStorageService.ContainKeyAsync("test"))
                SelectedYear = await LocalStorageService.GetItemAsync<int>("test");
            
            await JsNetBridgeService.InitAsync(null);
            await Init();
        }

        private async void OnDateChange(DateTimeChangedEventArgs args)
        {
            SelectedYear = args.Date.Year;
            await LocalStorageService.SetItemAsync<int>("test", SelectedYear);
            NavManager.NavigateTo(NavManager.Uri, true);
        }

        private async Task Init()
        {
            var result = (await JsonDepotService.GetDividendSumAsync()).GetXLastYears(DateTime.Now.Year - SelectedYear + 1);
            //var result = (await JsonDepotService.GetDividendSumAsync()).GetXLastYears(10);
            Years = result.Select(x => x.Year).OrderBy(x => x).Select(x => x.ToString()).ToArray();
            SumValuesPerYear = result.OrderBy(x => x.Year).Select(x => Math.Round(x.SumNetPerMonth.Sum(), 2)).ToArray();
            DividendSumsYears = result;
            XAxisDescriptions = new Dictionary<string, string>();

            foreach (var year in Years)
            {
                int yearNr = int.Parse(year);
                // is year before available
                int prevYearNr = yearNr - 1;
                var before = result.FirstOrDefault(x => x.Year == prevYearNr);
                if (before == null)
                {
                    XAxisDescriptions.Add(year, year);
                    continue;
                }
                var actual = result.First(x => x.Year == yearNr);
                var change = Math.Round((actual.SumNetPerMonth.Sum() - before.SumNetPerMonth.Sum()) / before.SumNetPerMonth.Sum() * 100, 2);
                XAxisDescriptions.Add(year, $"{year} ({change}%)");
            }
            // crazy stuff because razor yields always the last one and js functions are always async and can't be used here
            await JsNetBridgeService.SetValueAsync("xaxisdesc", JsonConvert.SerializeObject(XAxisDescriptions));

            object[] data = new object[DividendSumsYears.Count + 1];
            data[0] = new object[] { "Jahr", "Januar", "Februar", "März", "April", "Mai", "Juni",
            "Juli", "August", "September", "Oktober", "November", "Dezember"};

            int i = 1;
            List<DividendSumsYear> temp = new(DividendSumsYears);
            temp.Reverse();

            foreach (var yearSum in temp)
            {
                data[i] = new object[13];
                ((object[])data[i])[0] = yearSum.Year;
                for (int j = 1; j < 13; j++)
                {
                    double sum = 0d;
                    if (AppState.Value.IncomeType == Data.IncomeType.Gross)
                        sum = yearSum.SumGrossPerMonth[j - 1];
                    else
                        sum = yearSum.SumNetPerMonth[j - 1];
                    ((object[])data[i])[j] = Math.Round(sum, 2);
                }

                i++;
            }
            MonthlyData = data;

            data = new object[13];
            data[0] = new object[temp.Count + 1];

            ((object[])data[0])[0] = "Monat";
            var cultureInfo = CultureInfo.GetCultureInfo("de-DE");
            for (int j = 1; j < 13; j++)
            {
                data[j] = new object[temp.Count + 1];
                ((object[])data[j])[0] = cultureInfo.DateTimeFormat.GetMonthName(j);
            }

            i = 1;
            while (i < data.Length)
            {
                int j = 0;
                foreach (var yearSum in temp)
                {
                    double sum = 0d;
                    ((object[])data[0])[j + 1] = yearSum.Year.ToString();
                    if (AppState.Value.IncomeType == Data.IncomeType.Gross)
                        sum = yearSum.SumGrossPerMonth[i - 1];
                    else
                        sum = yearSum.SumNetPerMonth[i - 1];
                    ((object[])data[i])[j + 1] = Math.Round(sum, 2);
                    j++;
                }
                i++;
            }
            MonthlyComparisionData = data;

            InitSuccess = true;
            StateHasChanged();
        }

        internal void ExportYearTableToMarkdown()
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
