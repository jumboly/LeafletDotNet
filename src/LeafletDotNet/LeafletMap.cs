using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeafletDotNet.Extensions;
using Microsoft.Web.WebView2.Core;

namespace LeafletDotNet
{
    public class LeafletMap : LeafletObject
    {
        public async Task<LeafletMap> SetView(LeafletLatLng latLng, int zoom, LeafletZoomPanOptions options = null)
        {
            await Leaflet.Invoke(this, "setView", latLng, zoom, options);
            return this;
        }

        public async Task<LeafletMap> FitWorld()
        {
            await Leaflet.Invoke(this, "fitWorld");
            return this;
        }
    }
}
