using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Services
{
    internal class JsNetBridgeService : IDisposable
    {
        internal IJSRuntime JS { get; set; }

        private DotNetObjectReference<JsNetBridgeService> netObjectReference;

        internal Guid Guid { get; set; }

        private Func<string, string, string>? executeFunc;

        public JsNetBridgeService(IJSRuntime js)
        {
            JS = js;
            netObjectReference = DotNetObjectReference.Create(this);
            Guid = Guid.NewGuid();
        }

        public async Task InitAsync(Func<string, string, string>? func)
        {
            await JS.InvokeVoidAsync("window.divInterop.setReference", Guid, netObjectReference);
            executeFunc = func;
        }

        [JSInvokable("Execute")]
        public string Execute(string method, string param)
        {
            if (executeFunc == null)
                return string.Empty;
            return executeFunc(method, param);
        }

        public async Task SetValueAsync(string prop, string json)
        {
            await JS.InvokeVoidAsync("window.divInterop.setProperty", prop, json);
        }

        public void Dispose()
        {
            netObjectReference?.Dispose();
        }
    }
}
