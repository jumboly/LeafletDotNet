using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public class LeafletMouseEvent : LeafletEvent
    {
        public LeafletMouseEvent(string type, LeafletClass target, LeafletClass sourceTarget, LeafletLatLng latLng, LeafletPoint layerPoint, LeafletPoint containerPoint, DomMouseEvent originalEvent)
            : base(type, target, sourceTarget)
        {
            LatLng = latLng;
            LayerPoint = layerPoint;
            ContainerPoint = containerPoint;
            OriginalEvent = originalEvent;
        }

        public LeafletLatLng LatLng { get; }
        public LeafletPoint LayerPoint { get; }
        public LeafletPoint ContainerPoint { get; }
        public DomMouseEvent OriginalEvent { get; }
    }
}
