using DivVisualizer.Store.App;
using DivVizParqet.Data.Json;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVizParqet.Pages
{
    public partial class Dashboard : Fluxor.Blazor.Web.Components.FluxorComponent
    {
        [Inject]
        internal IState<AppState>? AppState { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        public bool IsDataAlreadyImported()
        {
            return AppState!.Value.LastSyncMeta != DateTime.MinValue || AppState!.Value.LastSyncStocks != DateTime.MinValue;
        }
    }
}
