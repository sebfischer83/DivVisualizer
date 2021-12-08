using DivVisualizer.Data;
using Fluxor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Store.App
{
    [FeatureState]
    internal record AppState
    {
        public DateTime LastSyncStocks { get; init; }

        public DateTime LastSyncMeta { get; init; }

        public ImportDataSource LastImportDataSource { get; init; }

        public string LastImportDataSourceDescription
        {
            get
            {
                return EnumHelper.GetDisplayName(LastImportDataSource);
            }
        }

        public AppState()
        {
            LastSyncStocks = DateTime.MinValue;
            LastSyncMeta = DateTime.MinValue;
            LastImportDataSource = ImportDataSource.None;
        }

        public AppState(DateTime lastSyncStocks, DateTime lastSyncMeta, ImportDataSource dataSource)
        {
            LastSyncStocks = lastSyncStocks;
            LastSyncMeta = lastSyncMeta;
            LastImportDataSource = dataSource;
        }
    }
}
