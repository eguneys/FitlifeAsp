
using System;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Fitlife.WebUI.Helpers
{
    public static class HtmlExtensions
    {

        public static MvcHtmlString TimeAgo(this HtmlHelper helper, DateTime dateTime)
        {
            dateTime = dateTime.ToUniversalTime();
            var tag = new TagBuilder("abbr");
            tag.AddCssClass("timeago");
            tag.Attributes.Add("title", dateTime.ToString("s") + "Z");
            tag.SetInnerText(dateTime.ToString());

            return MvcHtmlString.Create(tag.ToString());
        }

    }
}