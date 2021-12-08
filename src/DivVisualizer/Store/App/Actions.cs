using DivVisualizer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Store.App
{
    internal class LoadDataAction
    {
    }

    internal class LoadDataResultAction
    {
        public DateTime LastSyncStocks { get; }

        public DateTime LastSyncMetadata { get; }

        public ImportDataSource LastImportDataSource { get; }

        public LoadDataResultAction(DateTime lastSyncStocks, DateTime lastSyncMetadata, ImportDataSource dataSource)
        {
            LastSyncStocks = lastSyncStocks;
            LastSyncMetadata = lastSyncMetadata;
            LastImportDataSource = dataSource;
        }
    }
}
