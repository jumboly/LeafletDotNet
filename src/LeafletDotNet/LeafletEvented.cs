using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public class LeafletEvented : LeafletClass
    {
        public async Task On(string eventName, LeafletCallback callback)
        {
            await Leaflet.Callback(callback);
            await Leaflet.Invoke(this, "on", eventName, callback);
        }
    }
}
