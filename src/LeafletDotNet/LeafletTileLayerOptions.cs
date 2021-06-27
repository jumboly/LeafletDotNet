using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public class LeafletTileLayerOptions
    {
        public string Attribution { get; set; }
        public int? MinZoom { get; set; }
        public int? MaxZoom { get; set; }
    }
}
