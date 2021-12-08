using DivVisualizer.Data;
using DivVisualizer.Store.App;
using Fluxor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Components.DataSource
{
    public partial class ChooseDatasource
    {
        public List<string> Datasources { get; set; } = null!;

        public string? DefValue { get; set; }

        public string? SelectedValue { get; set; }

        public ImportDataSource SelectedSource { get; set; }

        [Inject]
        internal IState<AppState> AppState { get; set; } = null!;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Datasources = new List<string>();
            
            foreach (ImportDataSource dataSource in Enum.GetValues(typeof(ImportDataSource)))
            {
                Datasources.Add(EnumHelper.GetDisplayName(dataSource));
            }
            DefValue = EnumHelper.GetDisplayName(ImportDataSource.ParqetFile);
            SelectedSource = ImportDataSource.ParqetFile;
        }

        public void OnSelectedItemChangedHandler(string value)
        {
            SelectedSource = EnumHelper.GetEnumFromString<ImportDataSource>(value);
        }
    }
}
