using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Data.App
{
    internal class DatabaseStatistics
    {
        public int Id { get; set; } = 1;

        public int Stocks { get; set; }
        
        public int Dividends { get; set; }

        public double SumNetDividends { get; set; }

        public DateTime EarliestDate { get; set; }
        public double SumGrossDividends { get; internal set; }
    }
}
