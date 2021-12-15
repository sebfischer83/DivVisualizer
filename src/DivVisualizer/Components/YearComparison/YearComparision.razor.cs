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

        internal ECharts? OverviewChart;

        internal bool InitSuccess = false;

        internal List<DividendSumsYear> DividendSumsYears { get; set; } = null!;

        internal string[] Years { get; set; } = null!;

        internal double[] SumValuesPerYear { get; set; } = null!;

        internal Dictionary<string, string> XAxisDescriptions { get; set; } = null!;

        private const int YEARS_TO_SHOW = 10;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender)
                return;

            await JsNetBridgeService.InitAsync(null);
            var result = (await JsonDepotService.GetDividendSumAsync()).GetXLastYears(YEARS_TO_SHOW);

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
                var actual = result.First(x=> x.Year == yearNr);
                var change = Math.Round((actual.SumNetPerMonth.Sum() - before.SumNetPerMonth.Sum()) / before.SumNetPerMonth.Sum() * 100, 2);
                XAxisDescriptions.Add(year, $"{year} ({change}%)");
            }
            // crazy stuff because razor yields always the last one and js functions are always async and can't be used here
            await JsNetBridgeService.SetValueAsync("xaxisdesc", JsonConvert.SerializeObject(XAxisDescriptions));

            InitSuccess = true;
            StateHasChanged();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
