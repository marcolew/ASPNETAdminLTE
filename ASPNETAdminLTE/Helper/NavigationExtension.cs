using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Encodings.Web;

namespace ASPNETAdminLTE.Helper
{
    public static class NavigationExtension
    {

        public static IHtmlContent Navigation(this IHtmlHelper htmlHelper, List<NavigationEntry> navigationEntries)
        {
            var html = new HtmlContentBuilder();

            foreach (var n in navigationEntries)
            {
                var li = Extension.ActionLinkNavigation(htmlHelper, n.LinkText, n.ActionName, n.ControllerName, n.FaIncon);
                html.AppendHtml(Common.GetString(li));
            }

            return html;

        }


    }
}
