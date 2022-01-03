using DivVisualizer.Data.App;
using DivVisualizer.Data.Db;
using Microsoft.AspNetCore.Components.Forms;

namespace DivVisualizer.Services
{
    internal interface IDepotService
    {
        Task ImportStockDataFromParqetFile(IBrowserFile file);
        Task<DatabaseStatistics> GetDatabaseOverviewAsync();
        Task<List<DividendSumsYear>> GetDividendSumAsync();
        Task<List<Stock>> GetStocks();
        Task<List<Dividend>> GetDividendsForYear(int year);
    }
}