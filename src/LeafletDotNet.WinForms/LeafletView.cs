using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace LeafletDotNet.WinForms
{
    public partial class LeafletView : Control
    {
        private static string _webView2RuntimeFolder;
        public static void SetWebView2RuntimeFolder(string folder)
        {
            if (!Path.IsPathRooted(folder))
            {
                folder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), folder);
            }
            if (!Directory.Exists(folder))
            {
                throw new ArgumentException($"フォルダが存在しません:{folder}", nameof(folder));
            }
            _webView2RuntimeFolder = folder;
        }

        private readonly WebView2 _webView2;

        public LeafletView()
        {
            InitializeComponent();

            _webView2 = new WebView2()
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(_webView2);
        }

        public Leaflet L { get; private set; }

        public async Task InitAsync()
        {
            await _webView2.EnsureRuntimeAsync(_webView2RuntimeFolder);
            L = await Leaflet.CreateAsync(_webView2.CoreWebView2);
        }
    }
}
