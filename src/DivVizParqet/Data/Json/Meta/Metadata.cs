using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVizParqet.Data.Json.Meta
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class Metadata
    {
        public Metadata(
            List<Country> countries,
            List<Region> regions,
            List<Industry> industries,
            List<Sector> sectors,
            List<Type> types,
            SecurityDimensions securityDimensions,
            List<AssetDimension> assetDimensions
        )
        {
            this.countries = countries;
            this.regions = regions;
            this.industries = industries;
            this.sectors = sectors;
            this.types = types;
            this.securityDimensions = securityDimensions;
            this.assetDimensions = assetDimensions;
        }

        public IReadOnlyList<Country> countries { get; }
        public IReadOnlyList<Region> regions { get; }
        public IReadOnlyList<Industry> industries { get; }
        public IReadOnlyList<Sector> sectors { get; }
        public IReadOnlyList<Type> types { get; }
        public SecurityDimensions securityDimensions { get; }
        public IReadOnlyList<AssetDimension> assetDimensions { get; }
    }


}
