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
        public static IDisposable PanelDiv (this IHtmlHelper htmlHelper, string boxTitle, PanelSizeEnum size)
        {
            var writer = htmlHelper.ViewContext.Writer;

            var str = @"<div class=""col-md-{0}"">
              <div class=""box"">
            <div class=""box-header with-border"">
              <h3 class=""box-title"">{1}</h3>

              <div class=""box-tools pull-right"">
                <button type = ""button"" class=""btn btn-box-tool"" data-widget=""collapse""><i class=""fa fa-minus""></i></button>
                <button type = ""button"" class=""btn btn-box-tool"" data-widget=""remove""><i class=""fa fa-times""></i></button>
              </div>
            </div>
            <!-- /.box-header -->
            <div class=""box-body"">";

            writer.WriteLine(string.Format(str,(int)size, boxTitle));
            return new PanelContainer(writer);
        }

        public static IDisposable RowDiv(this IHtmlHelper htmlHelper)
        {
            var writer = htmlHelper.ViewContext.Writer;
            writer.WriteLine("<div class=\"row\">");
            return new RowContainer(writer);
        }
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
