using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public class LeafletMapOptions
    {
        /*
         * Options
         */
        public bool? PreferCanvas { get; set; }

        /*
         * Control Options
         */
        public bool? AttributionControl { get; set; }
        public bool? ZoomControl { get; set; }

        /*
         * Interaction Options
         */
        public bool? ClosePopupOnClick { get; set; }
        public double? ZoomSnap { get; set; }
        public double? ZoomDelta { get; set; }
        public bool? TrackResize { get; set; }
        public bool? BoxZoom { get; set; }
        public bool? DoubleClickZoom { get; set; }
        public bool? Dragging { get; set; }
    }
}
