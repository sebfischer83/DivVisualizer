using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using DivVisualizer.Data.Db;
using DivVisualizer.Services;
using DivVisualizer.Store;
using DnetIndexedDb;
using DnetIndexedDb.Models;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using TagEChartsBlazor.Configuration;

namespace DivVizParqet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //UseImmersiveDarkMode(this.Handle, true);
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            //serviceCollection.AddTransient<IndexedDbOptions, DbOptions>();

            serviceCollection.AddFluxor(o => o
                .ScanAssemblies(typeof(Program).Assembly).UseReduxDevTools(o => o.Name = "DivVizParqet").UseRouting().AddMiddleware<LoggingMiddleware>());
            serviceCollection.AddScoped<IDepotService, DepotService>();
            serviceCollection.AddScoped<JsNetBridgeService, JsNetBridgeService>();
            serviceCollection.AddECharts();

            serviceCollection.AddBlazoredLocalStorage(config =>
            {
                config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                config.JsonSerializerOptions.WriteIndented = true;
            });
            serviceCollection.AddSingleton<IErrorBoundaryLogger>(new NullErrorBoundaryLogger());
            serviceCollection.AddScoped(sp => new HttpClient { BaseAddress = new Uri("localhost") });
            serviceCollection.AddAntDesign();
            serviceCollection.AddIndexedDbDatabase<StockDataIndexDb>(options =>
            {
                options.UseDatabase(StockDataIndexDb.GetModel());
            });
            var blazor = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot/index.html",
                Services = serviceCollection.BuildServiceProvider()
            };
            blazor.RootComponents.Add<HeadOutlet>("head::after");

            blazor.RootComponents.Add<AppPage>("#app");

            //blazor.WebView.WebMessageReceived
            Controls.Add(blazor);
        }


        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }

        public class NullErrorBoundaryLogger : IErrorBoundaryLogger
        {
            public ValueTask LogErrorAsync(Exception exception)
            {
                return ValueTask.CompletedTask;
            }
        }
    }
}