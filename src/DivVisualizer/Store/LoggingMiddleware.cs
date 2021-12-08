using Fluxor;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Store
{
    internal class LoggingMiddleware : Middleware
    {
        private IStore? Store;
        private IJSRuntime? JSRuntime;

        public LoggingMiddleware(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime;
        }

        public override Task InitializeAsync(IStore store)
        {
            Store = store;
            Debug.WriteLine(nameof(InitializeAsync));
            return Task.CompletedTask;
        }

        public override void AfterInitializeAllMiddlewares()
        {
            Debug.WriteLine(nameof(AfterInitializeAllMiddlewares));
        }

        public override bool MayDispatchAction(object action)
        {
            Debug.WriteLine(nameof(MayDispatchAction) + ObjectInfo(action));
            return true;
        }

        public override void BeforeDispatch(object action)
        {
            Debug.WriteLine(nameof(BeforeDispatch) + ObjectInfo(action));
            //var task = Task.Run(() => JSRuntime.InvokeVoidAsync("window.console", ObjectInfo(action)));
        }

        public override void AfterDispatch(object action)
        {
            Debug.WriteLine(nameof(AfterDispatch) + ObjectInfo(action));
        }

        private string ObjectInfo(object obj)
            => ": " + obj.GetType().Name + " " + JsonConvert.SerializeObject(obj);
    }
}
