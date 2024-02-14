using DevExpress.Web.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using DevExpress.Web;

namespace DevExpress.Web.Demos {
    public class UnsupportedBrowserHttpModule : IHttpModule {
        const string PageContent = @"
<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <style>
        body {
            font: 16px ""Segoe UI"", ""Helvetica Neue"", Helvetica, ""Droid Sans"", Tahoma, Geneva, sans-serif;
            color: #333333;
            background-color: #fff;
            padding: 48px 8px 8px;
        }
        .container {
            margin: 0 auto;
            max-width: 800px;
            position: relative;
            width: 100%;
        }
        .container .image {
            position: absolute;
            width: 32px;
            padding: 8px 0;
        }
        .container .text {
            padding-left: 44px;
        }
        .container .text > h1 {
            font-weight: 600;
            margin: 0;
        }
        .container .text > p {
            margin: 12px 0;
        }
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""image"">
            <svg xmlns=""http://www.w3.org/2000/svg"" fill=""currentColor"" viewBox=""0 0 18 18"" width=""32px"" height=""32px""><path d=""M 8 7 h 2 V 5 H 8 M 9 16 c -4 0 -7 -3 -7 -7 s 3 -7 7 -7 s 7 3 7 7 S 13 16 9 16 M 9 0 C 4 0 0 4 0 9 c 0 5 4 9 9 9 c 5 0 9 -4 9 -9 C 18 4 14 0 9 0 M 8 13 h 2 V 8 H 8 V 13 Z"" /></svg>
        </div>
        <div class=""text"">
            <h1>Your browser is not supported.</h1>
            <p>Please open this webpage with a <a href=""https://www.devexpress.com/support/versions.xml"">supported web browser</a> to run DevExpress ASP.NET Component Demos.</p>
        </div>
    </div>
</body>
</html>";
        
        public void Dispose() { }

        public void Init(HttpApplication context) {
            context.BeginRequest += Context_BeginRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e) {
            string userAgent = HttpContext.Current.Request.UserAgent;
            if (!string.IsNullOrWhiteSpace(userAgent) && (userAgent.Contains("MSIE") || userAgent.Contains("Trident"))) {
                HttpUtils.WriteToResponse(PageContent);
                HttpUtils.EndResponse();
            }
        }
    }
}
