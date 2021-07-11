using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public class DomMouseEvent
    {
        public DomMouseEvent(bool altKey, int button, int buttons, int clientX, int clientY, bool ctrlKey, bool metaKey)
        {
            AltKey = altKey;
            Button = button;
            Buttons = buttons;
            ClientX = clientX;
            ClientY = clientY;
            CtrlKey = ctrlKey;
            MetaKey = metaKey;
        }

        public bool AltKey { get; }
        public int Button { get; }
        public int Buttons { get; }
        public int ClientX { get; }
        public int ClientY { get; }
        public bool CtrlKey { get; }
        public bool MetaKey { get; }
    }
}
