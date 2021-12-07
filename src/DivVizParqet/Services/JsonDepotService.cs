using DivVizParqet.Data.App;
using DivVizParqet.Data.Db;
using DivVizParqet.Data.Json;
using DivVizParqet.Store.App;
using Fluxor;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVizParqet.Services
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

        public async Task ImportStockData(IBrowserFile file)
        {
            var reader =
                await new StreamReader(file.OpenReadStream((long)UnitsNet.Information.FromMegabytes(5).Bytes))
                .ReadToEndAsync().ConfigureAwait(false);
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.TypeNameHandling = TypeNameHandling.All;
            jsonSerializerSettings.MetadataPropertyHandling = MetadataPropertyHandling.Default;

            var parqet = JsonConvert.DeserializeObject<ParqetExport>(reader, jsonSerializerSettings);

            // stocks
            List<Stock> stocks = new();
            foreach (var stockParqet in parqet.holdings)
            {
                Stock stock = new Stock(stockParqet._id, stockParqet.security.name, stockParqet.security.isin, stockParqet.security.wkn);
                stocks.Add(stock);
            }

            foreach (var activityParqet in parqet.activities.Where(x => 
                x.type.Equals("DIVIDEND", StringComparison.InvariantCultureIgnoreCase)))
            {
                
            }
        }
    }
}
