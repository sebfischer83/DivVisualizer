using DivVisualizer.Data.App;
using DivVisualizer.Store.App;
using DivVizParqet.Data.Json;
using Fluxor;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Services
{
    internal class JsonDepotService : IJsonDepotService
    {
        public JsonDepotService(IDispatcher dispatcher, IState<AppState> appState)
        {
            Dispatcher = dispatcher;
            AppState = appState;
        }

        public IDispatcher Dispatcher { get; }
        public IState<AppState> AppState { get; }

        public async Task ImportStockDataFromParqetFile(IBrowserFile file, Data.Db.StockDataIndexDb stockDataIndexDb)
        {
            await stockDataIndexDb.OpenIndexedDb();
            await stockDataIndexDb.AddItems<Stock>("Stocks", new List<Stock>() { new Stock("1", "Gazprom", "32243", "sdf") });
            var reader =
                await new StreamReader(file.OpenReadStream((long)UnitsNet.Information.FromMegabytes(5).Bytes))
                .ReadToEndAsync().ConfigureAwait(false);
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.TypeNameHandling = TypeNameHandling.All;
            jsonSerializerSettings.MetadataPropertyHandling = MetadataPropertyHandling.Default;

            var parqet = JsonConvert.DeserializeObject<ParqetExport>(reader, jsonSerializerSettings);

            if (parqet == null)
                throw new ArgumentException($"File is in wrong format and can't be parsed to {nameof(ParqetExport)}");

            // stocks
            List<Stock> stocks = new();
            foreach (var stockParqet in parqet.holdings)
            {
                Stock stock = new Stock(stockParqet._id, stockParqet.security.name, stockParqet.security.isin, stockParqet.security.wkn);
                stocks.Add(stock);
            }

            // dividends
            foreach (var activityParqet in parqet.activities.Where(x =>
                x.type.Equals("DIVIDEND", StringComparison.InvariantCultureIgnoreCase)))
            {

            }
        }
    }
}
