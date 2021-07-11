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

namespace Sandbox.WinForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            await leafletView1.InitAsync();

            var map = await leafletView1.L.Map(new LeafletMapOptions()
            {
                ZoomControl = false,
            });

            var layer = await leafletView1.L.TileLayer(
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

            await map.On("click", new LeafletCallback<LeafletMouseEvent>(e =>
            {
                MessageBox.Show(new
                {
                    e.Type,
                    e.LatLng,
                    e.ContainerPoint,
                    e.LayerPoint,
                    e.OriginalEvent.AltKey,
                    e.OriginalEvent.CtrlKey,
                    e.OriginalEvent.MetaKey,
                    e.OriginalEvent.Button,
                    e.OriginalEvent.Buttons,
                    e.OriginalEvent.ClientX,
                    e.OriginalEvent.ClientY,
                }.ToString());
            }));
        }
    }
}
