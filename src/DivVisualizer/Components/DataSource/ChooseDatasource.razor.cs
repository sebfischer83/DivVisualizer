using AntDesign;
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
    public partial class ChooseDatasource : Fluxor.Blazor.Web.Components.FluxorComponent
    {
        public DirectionVHType Direction = DirectionVHType.Vertical;

        public List<string> Datasources { get; set; } = null!;

        public string? SelectedValue { get; set; }

        public ImportDataSource SelectedSource { get; set; }

        [Inject]
        internal IState<AppState> AppState { get; set; } = null!;

        [Inject]
        internal Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; } = null!;

        private const string LastDataSourceKey = $"{nameof(ChooseDatasource)}.LastSelectedDataSource";

        public ChooseDatasource()
        {
            Datasources = new List<string>();

            foreach (ImportDataSource dataSource in Enum.GetValues(typeof(ImportDataSource)))
            {
                Datasources.Add(EnumHelper.GetDisplayName(dataSource));
            }

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (await LocalStorage.ContainKeyAsync(LastDataSourceKey))
                SelectedSource = await LocalStorage.GetItemAsync<ImportDataSource>(LastDataSourceKey);
            else
                SelectedSource = ImportDataSource.ParqetFile;
            SelectedValue = EnumHelper.GetDisplayName(SelectedSource);
        }

        public async void OnSelectedItemChangedHandlerAsync(string value)
        {
            SelectedSource = EnumHelper.GetEnumFromString<ImportDataSource>(value);
            await LocalStorage.SetItemAsync<ImportDataSource>(LastDataSourceKey, SelectedSource);
        }

        public string FormatDate(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return "nicht verfügbar";
            }
            return dateTime.ToString("G");
        }
    }
}
