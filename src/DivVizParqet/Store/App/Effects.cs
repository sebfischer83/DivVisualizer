using Blazored.LocalStorage;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVizParqet.Store.App
{
    internal class Effects
    {
        private const string StockKey = "Settings.LastSyncStocks";
        private const string MetadataKey = "Settings.LastSyncMetadata";

        public ILocalStorageService LocalStorageService { get; }

        public Effects(ILocalStorageService localStorageService)
        {
            LocalStorageService = localStorageService;
        }

        [EffectMethod(typeof(LoadDataAction))]
        public async Task HandleLoadDataAction(IDispatcher dispatcher)
        {
            DateTime lastSyncStocks = DateTime.MinValue;
            DateTime lastSyncMetadata = DateTime.MinValue;

            if (await LocalStorageService.ContainKeyAsync(StockKey))
                lastSyncStocks = await LocalStorageService.GetItemAsync<DateTime>(StockKey);
            if (await LocalStorageService.ContainKeyAsync(MetadataKey))
                lastSyncMetadata = await LocalStorageService.GetItemAsync<DateTime>(MetadataKey);

            dispatcher.Dispatch(new LoadDataResultAction(lastSyncStocks, lastSyncMetadata));
        }
    }
}
