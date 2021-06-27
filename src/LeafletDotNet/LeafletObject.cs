using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;

namespace LeafletDotNet
{
    public abstract class LeafletObject
    {
        internal Guid Id { get; set; }

        internal Leaflet Leaflet { get; set; }
    }
}
