using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;

namespace LeafletDotNet.Extensions
{
    static class CoreWebView2Extensions
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new (JsonSerializerDefaults.Web)
        {
            IgnoreNullValues = true
        };

        public static Task LoadHtmlStringAsync(this CoreWebView2 coreWebView2, string html)
        {
            var tcs = new TaskCompletionSource();

            coreWebView2.NavigationCompleted += NavigationCompleted;
            coreWebView2.NavigateToString(html);

            return tcs.Task;

            void NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
            {
                coreWebView2.NavigationCompleted -= NavigationCompleted;
                if (e.IsSuccess)
                {
                    tcs.SetResult();
                }
                else
                {
                    tcs.SetException(new Exception(e.WebErrorStatus.ToString()));
                }
            }
        }

        public static Task<string> InvokeAsync(this CoreWebView2 coreWebView2, string function, object args)
        {
            var argsJson = JsonSerializer.Serialize(args, JsonSerializerOptions);
            return coreWebView2.ExecuteScriptAsync($"{function}({argsJson})");
        }
    }
}
