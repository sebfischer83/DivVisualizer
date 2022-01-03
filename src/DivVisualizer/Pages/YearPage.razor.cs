using BlazorDownloadFile;
using DivVisualizer.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Pages
{
    public partial class YearPage
    {
        [Parameter]
        public int? CurrentYear { get; set; } = null!;

        [Inject]
        internal ExportService ExportService { get; set; } = null!;

        [Inject]
        internal IBlazorDownloadFileService BlazorDownloadFileService { get; set; } = null!;


        public async override Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
            CurrentYear = CurrentYear ?? (await ExportService.MaxYearWithDataAsync());
        }

        public async Task ExportDividendsToMarkdownAsync()
        {
            var year = CurrentYear ?? DateTime.Now.Year;
            var text = await ExportService.ExportDividendsAsync(year, Data.IncomeType.Net, 12);

            await BlazorDownloadFileService.DownloadFileFromText($"dividends_{year}.md", text,
                Encoding.UTF8, "text/plain", false);
        }
    }
}
