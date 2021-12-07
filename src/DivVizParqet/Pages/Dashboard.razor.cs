using DivVizParqet.Data.App;
using DivVizParqet.Data.Db;
using DivVizParqet.Data.Json;
using DivVizParqet.Services;
using DivVizParqet.Store.App;
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

        [Inject]
        internal IJsonDepotService? JsonDepotService { get; set; }

        [Inject]
        internal StockDataIndexDb StockDataIndexDb { get; set; }

        internal bool? IsLoading { get; set; }

        protected override Task OnInitializedAsync()
        {
            IsLoading = false;
            return base.OnInitializedAsync();
        }

        public bool IsDataAlreadyImported()
        {
            return AppState!.Value.LastSyncMeta != DateTime.MinValue || AppState!.Value.LastSyncStocks != DateTime.MinValue;
        }

        public async Task UploadStocksAsync(InputFileChangeEventArgs e)
        {
            await StockDataIndexDb.OpenIndexedDb();
            await StockDataIndexDb.AddItems<Stock>("Stocks", new List<Stock>() { new Stock("1", "Gazprom", "32243", "sdf") });
            return;
            IsLoading = true;
            await InvokeAsync(() => JsonDepotService!.ImportStockData(e.File));
            IsLoading = false;
        }
    }
}
