﻿using DivVisualizer.Data.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer
{
    internal static class Extensions
    {
        public static IList<DividendSumsYear> GetXLastYears(this IList<DividendSumsYear> list, int years)
        {
            if (years >= list.Count)
                return list;

            var possibleYears = list.Select(x => x.Year).Distinct().ToList();
            if (years >= possibleYears.Count)
                return list;

            var yearsLeft = possibleYears.OrderBy(x => x).Take(years).ToList();

            return list.Where(x => yearsLeft.Contains(x.Year)).ToList();
        }
    }
}
