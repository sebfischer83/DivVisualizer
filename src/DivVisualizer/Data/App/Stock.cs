using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Data.App
{
    internal class Stock
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Isin { get; set; }
        public string Wkn { get; set; }

        public Stock(string id, string name, string isin, string wkn)
        {
            Id = id;
            Name = name;
            Isin = isin;
            Wkn = wkn;
        }

        public override string ToString()
        {
            return $"{Name} {Id}";
        }
    }
}
