using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public class LeafletLayer : LeafletEvented
    {
        public async Task<LeafletLayer> AddTo(LeafletMap map)
        {
            await Leaflet.Invoke(this, "addTo", map);
            return this;
        }
    }
}
