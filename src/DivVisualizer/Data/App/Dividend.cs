using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Data.App
{
    internal class Dividend
    {
        public double GrossAmount { get; set; }

        public double NetAmount { get; set; }

        public DateTime PayDate { get; set; }

        public string ShareId { get; set; }

        public double Shares { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        [JsonIgnore]
        public double GrossAmountPerShare => Shares == 0 ? 0 : GrossAmount / Shares;

        [JsonIgnore]
        public double NetAmountPerShare => Shares == 0 ? 0 : NetAmount / Shares;

        public Dividend(string shareId, double grossAmount, double netAmount, DateTime payDate, double shares)
        {
            GrossAmount = grossAmount;
            NetAmount = netAmount;
            PayDate = payDate;
            ShareId = shareId;
            Shares = shares;
            Year = payDate.Year;
            Month = payDate.Month;
            Day = payDate.Day;
        }
    }
}
