using DivVisualizer.Data.Db;
using Microsoft.AspNetCore.Components.Forms;

namespace DivVisualizer.Services
{
    internal interface IJsonDepotService
    {
        Task ImportStockDataFromParqetFile(IBrowserFile file, StockDataIndexDb stockDataIndexDb);
    }
}