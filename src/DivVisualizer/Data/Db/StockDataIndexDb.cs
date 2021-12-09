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

            model.AddStore("Stocks").WithAutoIncrementingKey("tableId").AddUniqueIndex("id").AddIndex("name").AddIndex("isin");

            model.AddStore("Dividends").WithAutoIncrementingKey("tableId").AddUniqueIndex("id").AddIndex("ShareId").AddIndex("year")
                .AddIndex("month").AddIndex("day");

            model.AddStore("DividendSumsYear").WithAutoIncrementingKey("tableId").AddUniqueIndex("year");

            model.AddStore("DatabaseStatistics").WithKey("id").AddIndex("stocks");

            return model;
        }
    }
}
