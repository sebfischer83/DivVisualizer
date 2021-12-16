using BlazorDownloadFile;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Components.TableExport
{
    public partial class TableExportComponent<TItem>
    {
        [Parameter, EditorRequired]
        public AntDesign.Table<TItem> Table { get; set; } = null!;

        [Inject]
        IBlazorDownloadFileService BlazorDownloadFileService { get; set; } = null!;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        internal async Task ExportMarkdownAsync()
        {
            var data = '|' + string.Join('|', Table.ColumnContext.Columns.Select(c => c.Title)) + '|';
            data += Environment.NewLine + "|-	|-	 |-	 |";

            await BlazorDownloadFileService.DownloadFileFromText("export.md", data,
                Encoding.UTF8, "text/plain", false);
        }
    }
}
