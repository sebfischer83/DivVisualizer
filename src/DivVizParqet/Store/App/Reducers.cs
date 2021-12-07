using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVizParqet.Store.App
{
    internal static class Reducers
    {
        [ReducerMethod()]
        public static AppState ReduceLoadDataAction(AppState state, LoadDataAction action) =>
            state with { };

        [ReducerMethod()]
        public static AppState ReduceLoadDataResultAction(AppState state, LoadDataResultAction action) =>
            state with { LastSyncMeta = action.LastSyncMetadata, LastSyncStocks = action.LastSyncStocks };
    }
}
