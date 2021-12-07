using Microsoft.AspNetCore.Components.Forms;

namespace DivVizParqet.Services
{
    internal interface IJsonDepotService
    {
        Task ImportStockData(IBrowserFile file);
    }
}