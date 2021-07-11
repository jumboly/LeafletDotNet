using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public class LeafletLatLng
    {
        public LeafletLatLng(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public double Lat { get; }
        public double Lng { get; }

        public override string ToString()
        {
            return $"{nameof(Lat)}: {Lat}, {nameof(Lng)}: {Lng}";
        }
    }
}
