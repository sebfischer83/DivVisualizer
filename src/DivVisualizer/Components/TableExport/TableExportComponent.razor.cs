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

        [Parameter]
        public Action ExportMarkdownClicked { get; set;}

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        
    }

    public class TableData
    {

    }
}
