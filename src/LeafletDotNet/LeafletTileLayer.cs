using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeafletDotNet.Extensions;
using Microsoft.Web.WebView2.Core;

namespace LeafletDotNet
{
    public class LeafletTileLayer : LeafletObject
    {
        public async Task<LeafletTileLayer> AddTo(LeafletMap map)
        {
            await Leaflet.Invoke(this, "addTo", map);
            return this;
        }
    }
}