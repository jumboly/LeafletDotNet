using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LeafletDotNet.Extensions;
using Microsoft.Web.WebView2.Core;

namespace LeafletDotNet
{
    public class Leaflet
    {
        public static async Task<Leaflet> CreateAsync(CoreWebView2 coreWebView2)
        {
            await coreWebView2.LoadHtmlStringAsync(Properties.Resources.map);

            // 外部リンクは標準ブラウザで表示
            coreWebView2.NavigationStarting += (sender, args) =>
            {
                args.Cancel = true;
                Process.Start(new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = args.Uri
                });
            };

            return new Leaflet(coreWebView2);
        }

        private readonly CoreWebView2 _coreWebView2;

        private Leaflet(CoreWebView2 coreWebView2)
        {
            _coreWebView2 = coreWebView2;
        }

        public Task<LeafletMap> Map(LeafletMapOptions options = null)
        {
            return Create<LeafletMap>("map", "mapElement", options);
        }

        public Task<LeafletTileLayer> TileLayer(string urlTemplate, LeafletTileLayerOptions options = null)
        {
            return Create<LeafletTileLayer>("tileLayer", urlTemplate, options);
        }

        private async Task<T> Create<T>(string function, params object[] parameters)
            where T: LeafletObject, new()
        {
            var id = Guid.NewGuid();
            await _coreWebView2.InvokeAsync("create", new
            {
                id, function, parameters
            });

            var obj = new T();
            obj.Id = id;
            obj.Leaflet = this;

            return obj;
        }

        internal async Task Invoke(LeafletObject leafletObject, string function, params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] is LeafletObject obj)
                {
                    parameters[i] = obj.Id;
                }
            }
            await _coreWebView2.InvokeAsync("invoke", new
            {
                leafletObject.Id, function, parameters
            });
        }
    }
}
