using DnetIndexedDb;
using DnetIndexedDb.Fluent;
using DnetIndexedDb.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Data.Db
{
    internal class StockDataIndexDb : IndexedDbInterop
    {
        public StockDataIndexDb(IJSRuntime jsRuntime, IndexedDbOptions<StockDataIndexDb> indexedDbDatabaseOptions) : base(jsRuntime, indexedDbDatabaseOptions)
        {
        }

        public static IndexedDbDatabaseModel GetModel()
        {
            var model = new IndexedDbDatabaseModel()
                .WithName("DivVizParqet")
                .WithVersion(1)
                .WithModelId(0);

            model.AddStore("Stocks").WithAutoIncrementingKey("tableId").AddUniqueIndex("id").AddIndex("name");

            model.AddStore("Dividends").WithAutoIncrementingKey("tableId").AddUniqueIndex("id").AddIndex("name");

            return model;
        }
    }
}
