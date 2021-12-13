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

namespace DivVisualizer.Components.DataOverview
{
    public partial class DataOverview : Fluxor.Blazor.Web.Components.FluxorComponent
    {
        [Inject]
        internal IState<AppState> AppState { get; set; } = null!;

        [Inject]
        internal IDepotService JsonDepotService { get; set; } = null!;

        internal DatabaseStatistics? DatabaseOverview { get; set; }

        internal Dictionary<string, int> Column = new Dictionary<string, int> {
            { "xxl", 2 },
            { "xl", 2},
            { "lg", 2},
            { "md", 2},
            { "sm", 2},
            { "xs", 2}
        };

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            DatabaseOverview = await JsonDepotService.GetDatabaseOverviewAsync();
        }

    }
}
