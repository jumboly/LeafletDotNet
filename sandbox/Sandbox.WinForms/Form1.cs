using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeafletDotNet;
using Microsoft.Web.WebView2.WinForms;

namespace Sandbox.WinForms
{
    public partial class Form1 : Form
    {
        private Leaflet _leaflet;

        public Form1()
        {
            InitializeComponent();
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            await webView.EnsureRuntimeAsync();

            _leaflet = await Leaflet.CreateAsync(webView.CoreWebView2);

            var map = await _leaflet.Map();

            var layer = await _leaflet.TileLayer(
                "https://cyberjapandata.gsi.go.jp/xyz/pale/{z}/{x}/{y}.png",
                new LeafletTileLayerOptions()
                {
                    Attribution = "<a href=\"https://maps.gsi.go.jp/\">地理院地図</a>",
                    MinZoom = 5,
                    MaxZoom = 18
                });

            await layer.AddTo(map);

            await map.SetView(new LeafletLatLng(35.681178, 139.767723), 13, new LeafletZoomPanOptions()
            {
                Animate = true
            });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _leaflet = await Leaflet.CreateAsync(webView.CoreWebView2);

            var map = await _leaflet.Map();

            await map.FitWorld();

            var layer = await _leaflet.TileLayer(
                "https://cyberjapandata.gsi.go.jp/xyz/pale/{z}/{x}/{y}.png",
                new LeafletTileLayerOptions()
                {
                    Attribution = "<a href=\"https://maps.gsi.go.jp/\">地理院地図</a>",
                    MinZoom = 5,
                    MaxZoom = 18
                });

            await layer.AddTo(map);

            await map.SetView(new LeafletLatLng(35.681178, 139.767723), 13, new LeafletZoomPanOptions()
            {
                Animate = true
            });
        }
    }
}
