using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVizParqet.Store.App
{
    internal class LoadDataAction
    {
    }

    internal class LoadDataResultAction
    {
        public DateTime LastSyncStocks { get; }
        
        public DateTime LastSyncMetadata { get; }

        public LoadDataResultAction(DateTime lastSyncStocks, DateTime lastSyncMetadata)
        {
            LastSyncStocks = lastSyncStocks;
            LastSyncMetadata = lastSyncMetadata;
        }
    }
}
