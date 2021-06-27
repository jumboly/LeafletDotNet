using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public class LeafletZoomPanOptions : ILeafletZoomOptions, ILeafletPanOptions
    {
        public bool? Animate { get; set; }
        public double? Duration { get; set; }
    }
}
