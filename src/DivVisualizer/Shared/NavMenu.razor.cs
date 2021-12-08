using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;

namespace DivVisualizer.Shared
{
    public partial class NavMenu
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public string? Target { get; set; }
        
        protected override void OnInitialized()
        {
            Target = "";
            NavigationManager!.LocationChanged += LocationChanged;
            base.OnInitialized();
        }

        private void LocationChanged(object? sender, LocationChangedEventArgs e)
        {
            Uri uri = new Uri(e.Location);
            Target = uri.Segments.Count() > 1 ? uri.Segments[1] : "";
            StateHasChanged();
        }

        private string SetAppearance(string location) => (location == Target) ? "active" : "";
    }
}
