using DivVisualizer.Store.App;
using Fluxor;

namespace DivVizParqet.Store.App
{
    internal static class Reducers
    {
        [ReducerMethod()]
        public static AppState ReduceLoadDataAction(AppState state, LoadDataAction action) =>
            state with { };

        [ReducerMethod()]
        public static AppState ReduceLoadDataResultAction(AppState state, LoadDataResultAction action) =>
            state with { LastSyncMeta = action.LastSyncMetadata, 
                LastSyncStocks = action.LastSyncStocks, LastImportDataSource = action.LastImportDataSource };

        [ReducerMethod()]
        public static AppState ReduceSetImportDataAction(AppState state, SetImportDataAction action) =>
            state with
            { };
    }
}
