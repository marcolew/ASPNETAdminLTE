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

        private static string GetString(IHtmlContent content)
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        public static IHtmlContent ActionLinkNavigation(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            var url = String.Format("/{0}/{1}", controllerName, actionName);
            var li = new TagBuilder("li");

            var a = new TagBuilder("a");
            a.Attributes["href"] =url;
            //a.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            var i = new TagBuilder("i");
            i.MergeAttribute("class", "fa fa-link");

            var span = new TagBuilder("span");
            span.InnerHtml.Append(linkText);

            a.InnerHtml.AppendHtml(GetString(i));
            a.InnerHtml.AppendHtml(GetString(span));
            li.InnerHtml.AppendHtml(GetString(a));
            return li;

            //< li >< a href = "#" >< i class="fa fa-link"></i> <span>Another Link</span></a></li>
        }


    }
}
