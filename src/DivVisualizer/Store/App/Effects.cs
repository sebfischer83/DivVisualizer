using Blazored.LocalStorage;
using DivVisualizer.Data;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Store.App
{
    internal class Effects
    {
        private const string StockKey = "Settings.LastSyncStocks";
        private const string MetadataKey = "Settings.LastSyncMetadata";
        private const string ImportSourceKey = "Settings.LastImportDataSource";

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
            ImportDataSource importDataSource = ImportDataSource.None;

            if (await LocalStorageService.ContainKeyAsync(StockKey))
                lastSyncStocks = await LocalStorageService.GetItemAsync<DateTime>(StockKey);
            if (await LocalStorageService.ContainKeyAsync(MetadataKey))
                lastSyncMetadata = await LocalStorageService.GetItemAsync<DateTime>(MetadataKey);
            if (await LocalStorageService.ContainKeyAsync(ImportSourceKey))
                importDataSource = await LocalStorageService.GetItemAsync<ImportDataSource>(ImportSourceKey);

            dispatcher.Dispatch(new LoadDataResultAction(lastSyncStocks, lastSyncMetadata, importDataSource));
        }

        [EffectMethod()]
        public async Task HandleSetImportDataAction(SetImportDataAction setImportDataAction, IDispatcher dispatcher)
        {
            if (setImportDataAction.LastSyncStocks != DateTime.MinValue)
                await LocalStorageService.SetItemAsync(StockKey, setImportDataAction.LastSyncStocks);

            if (setImportDataAction.LastSyncMetadata != DateTime.MinValue)
                await LocalStorageService.SetItemAsync(MetadataKey, setImportDataAction.LastSyncMetadata);

            await LocalStorageService.SetItemAsync(ImportSourceKey, setImportDataAction.LastImportDataSource);

            dispatcher.Dispatch(new LoadDataResultAction(setImportDataAction.LastSyncStocks ?? DateTime.MinValue,
                setImportDataAction.LastSyncMetadata ?? DateTime.MinValue, setImportDataAction.LastImportDataSource));
        }
    }
}
