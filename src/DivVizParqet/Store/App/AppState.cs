using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVizParqet.Store.App
{
    [FeatureState]
    internal record AppState
    {
        public DateTime LastSyncStocks { get; init; }

        public DateTime LastSyncMeta { get; init; }

        public AppState()
        {
            LastSyncStocks = DateTime.MinValue;
            LastSyncMeta = DateTime.MinValue;
        }

        public AppState(DateTime lastSyncStocks, DateTime lastSyncMeta)
        {
            LastSyncStocks = lastSyncStocks;
            LastSyncMeta = lastSyncMeta;
        }
    }
}
