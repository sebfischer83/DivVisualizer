using DivVisualizer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Services
{
    internal class ExportService
    {
        private readonly IDepotService depotService;

        public ExportService(IDepotService depotService)
        {
            this.depotService = depotService;
        }

        public async Task<int> MaxYearWithDataAsync()
        {
            var overview = await depotService.GetDatabaseOverviewAsync();

            return overview.MaxDate.Year;
        }

        public async Task<string> ExportDividendsAsync(int year, IncomeType incomeType = IncomeType.Net, int month = -1)
        {
            var yearData = await depotService.GetDividendsForYear(year);
            if (month > 0)
                yearData = yearData.Where(x => x.Month == month).ToList();

            if (yearData == null)
                return string.Empty;

            var stocks = await depotService.GetStocks();

            var groups = from y in yearData
                         group y by y.ShareId into g
                         select new { ShareId = g.Key, SumNet = g.Sum(x => Math.Round(x.NetAmount, 2)), SumGross = g.Sum(x => Math.Round(x.GrossAmount, 2)) } into s
                         orderby incomeType == IncomeType.Net ? s.SumNet : s.SumGross descending
                         select s;

            var data = '|' + "Unternehmen" + '|' + "Dividende" + '|';
            data += Environment.NewLine + "|-	|-	|";
            
            var sum = groups.Sum(x => incomeType == IncomeType.Net ? x.SumNet : x.SumGross);
            sum = Math.Round(sum, 2);

            foreach (var group in groups)
            {
                var stock = stocks.FirstOrDefault(x => x.Id == group.ShareId);
                if (stock == null)
                    continue;
                var s = (incomeType == IncomeType.Net ? group.SumNet : group.SumGross);
                s = Math.Round(s, 2);
                data += Environment.NewLine + $"| {stock.Name} | {s} |";
            }
            data += Environment.NewLine + $"| Gesamt:	| {sum} 	|";

            return data;
        }
    }
}
