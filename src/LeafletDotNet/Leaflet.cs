using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using LeafletDotNet.Extensions;
using Microsoft.Web.WebView2.Core;

namespace LeafletDotNet
{
    public class Leaflet
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web);

        public static async Task<Leaflet> CreateAsync(CoreWebView2 coreWebView2)
        {
            // リソースからHTML読み込み
            await using var stream = typeof(Leaflet).Assembly.GetManifestResourceStream($"{typeof(Leaflet).Namespace}.Html.map.html");
            Debug.Assert(stream != null);
            using var reader = new StreamReader(stream);

            await coreWebView2.LoadHtmlStringAsync(await reader.ReadToEndAsync());

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
            _coreWebView2.WebMessageReceived += CoreWebView2OnWebMessageReceived;
        }

        public Task<LeafletMap> Map(LeafletMapOptions options = null)
        {
            return Create<LeafletMap>("map", "mapElement", options);
        }

        public Task<LeafletTileLayer> TileLayer(string urlTemplate, LeafletTileLayerOptions options = null)
        {
            return Create<LeafletTileLayer>("tileLayer", urlTemplate, options);
        }

        public Task<LeafletGeoJSON> GeoJSON(string data, LeafletGeoJSONOptions options = null)
        {
            return Create<LeafletGeoJSON>("geoJSON", JsonSerializer.Deserialize<JsonDocument>(data), options);
        }

        internal async Task<T> Create<T>(string function, params object[] parameters)
            where T: LeafletClass, new()
        {
            var obj = new T();

            await _coreWebView2.InvokeAsync("__create", new
            {
                obj.Id, function, parameters
            });

            obj.Leaflet = this;

            return obj;
        }

        internal async Task Invoke(LeafletObject target, string function, params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] is LeafletObject obj)
                {
                    parameters[i] = obj.Id;
                }
            }
            await _coreWebView2.InvokeAsync("__invoke", new
            {
                target.Id, function, parameters
            });
        }

        internal async Task Callback(LeafletCallback callback)
        {
            await _coreWebView2.InvokeAsync("__callback", new
            {
                callback.Id
            });
        }

        internal async Task Dispose(LeafletObject target)
        {
            await _coreWebView2.InvokeAsync("__dispose", new
            {
                target.Id
            });
        }

        private void CoreWebView2OnWebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var message = JsonSerializer.Deserialize<Message>(e.WebMessageAsJson, _jsonSerializerOptions);
            var callback = LeafletObject.GetOrNull(message.Id) as LeafletCallback;
            callback?.Invoke(message.Event);
        }

        class Message
        {
            public Message(Guid id, JsonElement @event)
            {
                Id = id;
                Event = @event;
            }

            public Guid Id { get; }
            public JsonElement Event { get; }
        }
    }
}
