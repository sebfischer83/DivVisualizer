using AntDesign;
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
        internal IDepotService JsonDepotService { get; set; } = null!;

        //[Inject]
        //internal StockDataIndexDb StockDataIndexDb { get; set; } = null!;

        [Inject]
        internal IState<AppState> AppState { get; set; } = null!;

        [Inject]
        internal MessageService MessageService { get; set; } = null!;



        public bool IsProcessing
        {
            get
            {
                return isProcessing;
            }
            set
            {
                isProcessing = value;
            }
        }

        private bool isProcessing;

        public async Task UploadParqetStocksFileAsync(InputFileChangeEventArgs e)
        {
            IsProcessing = true;
            try
            {
                await JsonDepotService.ImportStockDataFromParqetFile(e.File);
                await MessageService.Info("Fertig", 2.5);
            }
            catch (Exception ex)
            {
                await MessageService.Error(ex.Message, 2.5);
            }
            finally
            {
                IsProcessing = false;
            }
        }
    }
}
