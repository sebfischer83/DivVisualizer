using DivVisualizer.Data.App;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace DivVisualizer.Tests
{
    public class ExtensionTests
    {
        [Fact]
        public void Test_Get_X_Last_Years_Less_Data()
        {
            List<DividendSumsYear> dividendSums = new();
            dividendSums.Add(new DividendSumsYear(2011, new double[12], 1, 1));
            dividendSums.Add(new DividendSumsYear(2012, new double[12], 1, 1));
            dividendSums.Add(new DividendSumsYear(2013, new double[12], 1, 1));
            dividendSums.Add(new DividendSumsYear(2014, new double[12], 1, 1));
            dividendSums.Add(new DividendSumsYear(2015, new double[12], 1, 1));
            dividendSums.Add(new DividendSumsYear(2016, new double[12], 1, 1));

            var filtered = dividendSums.GetXLastYears(7);
            filtered.ShouldBeEquivalentTo(dividendSums);
        }
    }
}