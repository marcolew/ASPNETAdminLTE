using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Text.Encodings.Web;

namespace ASPNETAdminLTE.Helper
{
    public static class Extension
    {

        public static IHtmlContent ActionLinkNavigation(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string faIcon)
        {
            var url = Common.GetURL(actionName, controllerName);
            var li = new TagBuilder("li");

            var a = new TagBuilder("a");
            a.Attributes["href"] =url;
            //a.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            var i = new TagBuilder("i");
            i.MergeAttribute("class", String.Format("fa {0}", faIcon));

            var span = new TagBuilder("span");
            span.InnerHtml.Append(linkText);

            a.InnerHtml.AppendHtml(Common.GetString(i));
            a.InnerHtml.AppendHtml(Common.GetString(span));
            li.InnerHtml.AppendHtml(Common.GetString(a));
            return li;

        }


    }
}
