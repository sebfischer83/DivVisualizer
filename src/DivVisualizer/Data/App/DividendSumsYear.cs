using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Data.App
{
    internal class DividendSumsYear
    {
        public int Year { get; set; }

        public double[] SumNetPerMonth { get; set; }

        public double[] SumGrossPerMonth { get; set; }

        public double[] CumulativeSumNetPerMonth { get; set; }

        public double[] CumulativeGrossNetPerMonth { get; set; }

        public int Paydays { get; set; }

        public int UnqiuePaydays { get; set; }

        public Dictionary<string, List<Dividend>> ByStock { get; }

        public DividendSumsYear(int year, double[] sumNetPerMonth, double[] sumGrossPerMonth, int paydays, int unqiuePaydays, Dictionary<string, List<Dividend>> byStock)
        {
            if (sumNetPerMonth.Length < 12)
            {
                throw new ArgumentException($"{sumNetPerMonth} must be 12 entries long");
            }

            if (sumGrossPerMonth.Length < 12)
            {
                throw new ArgumentException($"{sumGrossPerMonth} must be 12 entries long");
            }

            CumulativeSumNetPerMonth = new double[12];
            CumulativeGrossNetPerMonth = new double[12];
            SumNetPerMonth = sumNetPerMonth;
            SumGrossPerMonth = sumGrossPerMonth;
            Year = year;
            
            double sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += sumNetPerMonth[i];
                CumulativeSumNetPerMonth[i] = sum;
            }

            sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += sumGrossPerMonth[i];
                CumulativeGrossNetPerMonth[i] = sum;
            }
            Paydays = paydays;
            UnqiuePaydays = unqiuePaydays;
            ByStock = byStock;
        }
    }
}
