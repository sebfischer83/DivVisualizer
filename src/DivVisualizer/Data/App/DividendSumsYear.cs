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

        public double[] SumPerMonth { get; set; }

        public double[] CumulativeSumPerMonth { get; set; }

        public int Paydays { get; set; }

        public int UnqiuePaydays { get; set; }

        public DividendSumsYear(int year, double[] sumPerMonth, int paydays, int unqiuePaydays)
        {
            if (sumPerMonth.Length < 12)
            {
                throw new ArgumentException($"{sumPerMonth} must be 12 entries long");
            }

            CumulativeSumPerMonth = new double[12];
            SumPerMonth = sumPerMonth;
            Year = year;
            
            double sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += sumPerMonth[i];
                CumulativeSumPerMonth[i] = sum;
            }
            Paydays = paydays;
            UnqiuePaydays = unqiuePaydays;
        }
    }
}
