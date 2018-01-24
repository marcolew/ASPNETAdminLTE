using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ASPNETAdminLTE.Helper
{
    public static class Common
    {
        public static string GetString(IHtmlContent content)
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        public static string GetURL(string actionName, string controllerName)
        {
            return String.Format("/{0}/{1}", controllerName, actionName);
        }

    }
}
