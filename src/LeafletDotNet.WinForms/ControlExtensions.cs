using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeafletDotNet.WinForms
{
    static class ControlExtensions
    {
        public static IEnumerable<Control> Ancestors(this Control control)
        {
            for (var parent = control.Parent; parent != null; parent = parent.Parent)
            {
                yield return parent;
            }
        }
    }
}
