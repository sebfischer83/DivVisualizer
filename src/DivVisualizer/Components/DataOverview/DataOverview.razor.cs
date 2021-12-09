using DivVisualizer.Data.App;
using DivVisualizer.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Components.DataOverview
{
    public partial class DataOverview
    {
        [Inject]
        internal IDepotService JsonDepotService { get; set; } = null!;

        internal DatabaseStatistics? DatabaseOverview { get; set; }

        internal Dictionary<string, int> Column = new Dictionary<string, int> {
            { "xxl", 1 },
            { "xl", 1},
            { "lg", 1},
            { "md", 1},
            { "sm", 1},
            { "xs", 1}
        };

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            DatabaseOverview = await JsonDepotService.GetDatabaseOverviewAsync();
            StateHasChanged();
        }

    }
}
