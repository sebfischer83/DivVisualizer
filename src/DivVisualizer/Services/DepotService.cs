using DivVisualizer.Data.App;
using DivVisualizer.Data.Db;
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
    internal class DepotService : IDepotService
    {
        public DepotService(IDispatcher dispatcher, IState<AppState> appState, StockDataIndexDb stockDataIndexDb)
        {
            Dispatcher = dispatcher;
            AppState = appState;
            StockDataIndexDb = stockDataIndexDb;
        }

        public IDispatcher Dispatcher { get; }
        public IState<AppState> AppState { get; }
        public StockDataIndexDb StockDataIndexDb { get; }

        public async Task ImportStockDataFromParqetFile(IBrowserFile file)
        {
            var reader =
                await new StreamReader(file.OpenReadStream((long)UnitsNet.Information.FromMegabytes(5).Bytes))
                .ReadToEndAsync().ConfigureAwait(false);
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.TypeNameHandling = TypeNameHandling.All;
            jsonSerializerSettings.MetadataPropertyHandling = MetadataPropertyHandling.Default;

            var parqet = JsonConvert.DeserializeObject<ParqetExport>(reader, jsonSerializerSettings);

            if (parqet == null)
                throw new ArgumentException($"File is in wrong format and can't be parsed to {nameof(ParqetExport)}");

            // ready for import, delete all old data
            await StockDataIndexDb.OpenIndexedDb();
            await StockDataIndexDb.DeleteAll("Stocks");
            await StockDataIndexDb.DeleteAll("Dividends");
            await StockDataIndexDb.DeleteAll("DatabaseStatistics");
            await StockDataIndexDb.DeleteAll("DividendSumsYear");

            // stocks
            List<Stock> stocks = new();
            foreach (var stockParqet in parqet.holdings)
            {
                Stock stock = new Stock(stockParqet._id, stockParqet.security.name, stockParqet.security.isin, stockParqet.security.wkn);
                stocks.Add(stock);
            }

            List<Dividend> dividends = new List<Dividend>();
            // dividends
            foreach (var activityParqet in parqet.activities.Where(x =>
                x.type.Equals("DIVIDEND", StringComparison.InvariantCultureIgnoreCase)))
            {
                Dividend dividend = new Dividend(activityParqet.holding, activityParqet.amount ?? 0,
                    (activityParqet.amount ?? 0) - activityParqet.fee - activityParqet.tax, activityParqet.datetime,
                    activityParqet.shares);
                dividends.Add(dividend);
            }

            var holdings = dividends.Select(dividend => dividend.ShareId).Distinct().ToHashSet();
            stocks = stocks.Where(s => holdings.Contains(s.Id)).ToList();

            await StockDataIndexDb.AddItems("Stocks", stocks);
            await StockDataIndexDb.AddItems("Dividends", dividends);
            await PreparePreCalculatedDataAsync(stocks, dividends);

            Dispatcher.Dispatch(new SetImportDataAction(DateTime.Now, DateTime.Now, Data.ImportDataSource.ParqetFile));
        }

        private async Task PreparePreCalculatedDataAsync(List<Stock> stocks, List<Dividend> dividends)
        {
            foreach (var year in dividends.GroupBy(d => d.Year))
            {
                double[] monthlyNet = new double[12];
                double[] monthlyGross = new double[12];
                foreach (var div in year)
                {
                    monthlyNet[div.Month - 1] += div.NetAmount;
                    monthlyGross[div.Month - 1] += div.GrossAmount;
                }
                var allDividends = year.ToList();
                var unqiue = allDividends.Select(dividend => dividend.PayDate.Date).Distinct().Count();

                var byStock = year.GroupBy(d => d.ShareId).ToDictionary(k => k.Key, g => g.ToList());

                DividendSumsYear dividendSumsYear = new DividendSumsYear(year.Key, monthlyNet, monthlyGross,
                    allDividends.Count, unqiue, byStock);
                await StockDataIndexDb.AddItems("DividendSumsYear", new List<DividendSumsYear>() { dividendSumsYear });
            }

            DatabaseStatistics databaseStatistics = new DatabaseStatistics();
            databaseStatistics.Stocks = stocks.Count;
            databaseStatistics.Dividends = dividends.Count;
            databaseStatistics.Paydays = dividends.DistinctBy(a => a.PayDate).Count();
            databaseStatistics.EarliestDate = dividends.Min(d => d.PayDate);
            databaseStatistics.SumNetDividends = dividends.Sum(d => d.NetAmount);
            databaseStatistics.SumGrossDividends = dividends.Sum(d => d.GrossAmount);
            databaseStatistics.ByStocks = dividends.GroupBy(d => d.ShareId).
                ToDictionary(d => d.Key, g => g.ToList());

            await StockDataIndexDb.AddItems("DatabaseStatistics", new List<DatabaseStatistics>() { databaseStatistics });
        }

        public async Task<List<DividendSumsYear>> GetDividendSumAsync()
        {
            await StockDataIndexDb.OpenIndexedDb();
            return await StockDataIndexDb.GetAll<DividendSumsYear>("DividendSumsYear");
        }

        public async Task<DatabaseStatistics> GetDatabaseOverviewAsync()
        {
            await StockDataIndexDb.OpenIndexedDb();

            return await StockDataIndexDb.GetByKey<int, DatabaseStatistics>("DatabaseStatistics", 1);
        }
    }
}
