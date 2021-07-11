using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public class LeafletEvent
    {
        public LeafletEvent(string type, LeafletClass target, LeafletClass sourceTarget)
        {
            Type = type;
            Target = target;
            SourceTarget = sourceTarget;
        }

        public string Type { get; }
        public LeafletClass Target { get; }
        public LeafletClass SourceTarget { get; }
    }
}
