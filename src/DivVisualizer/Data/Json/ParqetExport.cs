using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DivVizParqet.Data.Json
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class ParqetExport
    {
        public ParqetExport(
            //Performance performance,
            List<Activity> activities,
            List<Holding> holdings,
            Portfolio portfolio,
            List<FutureDividend> futureDividends,
            AbsoluteValuePaths absoluteValuePaths
        )
        {
            //this.performance = performance;
            this.activities = activities;
            this.holdings = holdings;
            this.portfolio = portfolio;
            this.futureDividends = futureDividends;
            this.absoluteValuePaths = absoluteValuePaths;
        }

        //public Performance performance { get; }
        public IReadOnlyList<Activity> activities { get; }
        public IReadOnlyList<Holding> holdings { get; }
        public Portfolio portfolio { get; }
        public IReadOnlyList<FutureDividend> futureDividends { get; }
        public AbsoluteValuePaths absoluteValuePaths { get; }
    }




}
