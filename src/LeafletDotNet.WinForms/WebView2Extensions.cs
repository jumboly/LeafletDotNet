using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

// ReSharper disable once CheckNamespace
namespace Microsoft.Web.WebView2.WinForms
{
    static class WebView2Extensions
    {
        public static async Task EnsureRuntimeAsync(this WebView2 webView2, string runtileFolder = default)
        {
            if (runtileFolder != null && Path.IsPathRooted(runtileFolder))
            {
                runtileFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), runtileFolder);
            }

            var environment = await CoreWebView2Environment.CreateAsync(runtileFolder).ConfigureAwait(false);
            await webView2.EnsureCoreWebView2Async(environment).ConfigureAwait(false);
        }
    }
}
