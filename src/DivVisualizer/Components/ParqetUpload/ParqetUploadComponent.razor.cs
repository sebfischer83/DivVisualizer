using DivVisualizer.Data.Db;
using DivVisualizer.Services;
using DivVisualizer.Store.App;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVizParqet.Components.ParqetUpload
{
    public partial class ParqetUploadComponent
    {
        [Inject]
        internal IJsonDepotService JsonDepotService { get; set; } = null!;

        [Inject]
        internal StockDataIndexDb StockDataIndexDb { get; set; } = null!;

        [Inject]
        internal IState<AppState> AppState { get; set; } = null!;

        [Parameter]
        public EventCallback<bool> IsProcessingEvent { get; set; }

        public bool IsProcessing
        {
            get
            {
                return isProcessing;
            }
            set
            {
                isProcessing = value;
                Task.Run(() => IsProcessingEvent.InvokeAsync(isProcessing));
            }
        }

        private bool isProcessing;

        public async Task UploadParqetStocksFileAsync(InputFileChangeEventArgs e)
        {
            IsProcessing = true;
            await JsonDepotService.ImportStockDataFromParqetFile(e.File, StockDataIndexDb);
            IsProcessing = false;
        }
    }
}
