using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VuejsExamples.Helpers
{
    public static class AntiForgeryTokenHelpers
    {
        public static MvcHtmlString AntiForgeryTokenForAjaxPostInVue(this HtmlHelper helper)
        {
            var antiForgeryInputTag = helper.AntiForgeryToken().ToString();
            var removedStart = antiForgeryInputTag.Replace(@"<input name=""__RequestVerificationToken"" type=""hidden"" value=""", "");
            var tokenValue = removedStart.Replace(@""" />", "");
            if (antiForgeryInputTag == removedStart || removedStart == tokenValue)
                throw new InvalidOperationException("Oops! The Html.AntiForgeryTokenHelper() method seems to return something I did not expect.");
            return new MvcHtmlString(string.Format(@"{0}", tokenValue));
        }

    }
}