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
                if (n.Children.Count > 0)
                {
                    var li = ActionLinkTopLevelChildren(htmlHelper, n.LinkText, n.ActionName, n.ControllerName, n.FaIncon, n.Children);
                    html.AppendHtml(Common.GetString(li));
                }
                else
                {
                    var li = ActionLinkTopLevel(htmlHelper, n.LinkText, n.ActionName, n.ControllerName, n.FaIncon);
                    html.AppendHtml(Common.GetString(li));
                }
            }

            return html;

        }

        private static IHtmlContent ActionLinkTopLevel(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string faIcon)
        {
            var url = Common.GetURL(actionName, controllerName);
            var li = new TagBuilder("li");

            var a = new TagBuilder("a");
            a.Attributes["href"] = url;
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

        private static IHtmlContent ActionLinkTopLevelChildren(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string faIcon, List<NavigationEntry> children)
        {
            string url = Common.GetURL(actionName, controllerName);
            var li = new TagBuilder("li");
            li.MergeAttribute("class", "treeview");

            var a = new TagBuilder("a");
            a.Attributes["href"] = url;
            //a.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            var i = new TagBuilder("i");
            i.MergeAttribute("class", String.Format("fa {0}", faIcon));

            var span = new TagBuilder("span");
            span.InnerHtml.Append(linkText);

            var span2 = new TagBuilder("span");
            span2.MergeAttribute("class", "pull-right-container");
            var i2 = new TagBuilder("i");
            i2.MergeAttribute("class", "fa fa-angle-left pull-right");
            span2.InnerHtml.AppendHtml(Common.GetString(i2));

            var ul = new TagBuilder("ul");
            ul.MergeAttribute("class", "treeview-menu");
            foreach(var c in children)
            {
                var citem = Extension.ActionLinkNavigation(htmlHelper, c.LinkText, c.ActionName, c.ControllerName, c.FaIncon);
                ul.InnerHtml.AppendHtml(Common.GetString(citem));
            }

            a.InnerHtml.AppendHtml(Common.GetString(i));
            a.InnerHtml.AppendHtml(Common.GetString(span));
            a.InnerHtml.AppendHtml(Common.GetString(span2));
            li.InnerHtml.AppendHtml(Common.GetString(a));
            li.InnerHtml.AppendHtml(Common.GetString(ul));
            return li;

        }

    }
}
