using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace WebApplicationNetCoreDev.Helpers
{
    /// <summary>
    /// Helper Display script in end of body
    /// </summary>
    public static class ScriptsTagHelpers
    {
        /// <summary>
        /// Add script to HttpContext
        /// 
        /// Add in top on .cshtml:
        /// @using WebApplicationNetCoreDev.Helpers
        /// 
        /// Add script as:
        /// @Html.Script(
        /// @<script type = "text/javascript" >
        /// $(function () {
        /// });
        /// </script>)
        /// </summary>
        /// <param name="htmlHelper">IHtmlHelper htmlHelper</param>
        /// <param name="template">HtmlString.Empty</param>
        /// <returns></returns>
        public static HtmlString Script(this IHtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            htmlHelper.ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = template;
            return HtmlString.Empty;
        }
        /// <summary>
        /// Display script in bootom main page or other template
        /// Add in top on .cshtml:
        /// @using WebApplicationNetCoreDev.Helpers
        /// 
        /// And add in bootom section example:
        /// @Html.RenderScripts()
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static HtmlString RenderScripts(this IHtmlHelper htmlHelper)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (key.ToString().StartsWith("_script_"))
                {
                    Func<object, HelperResult> template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                    if (template != null)
                    {
                        htmlHelper.ViewContext.Writer.Write(template(null));
                    }
                }
            }
            return HtmlString.Empty;
        }
    }
}