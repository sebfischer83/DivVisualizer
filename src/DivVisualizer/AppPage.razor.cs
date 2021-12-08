using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivVisualizer.Store.App;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace DivVizParqet
{
    public partial class AppPage : Fluxor.Blazor.Web.Components.FluxorComponent
    {
        [Inject]
        private IState<AppState> AppState { get; set; } = null!;

        [Inject]
        public IDispatcher Dispatcher { get; set; } = null!;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new LoadDataAction());
        }
    }
}
