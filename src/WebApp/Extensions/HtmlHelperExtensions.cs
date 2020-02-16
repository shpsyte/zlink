using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Extensions {

    public static class HtmlHelperExtensions {
        public static IHtmlContent RouteIf (this IHtmlHelper helper, string value, string controller, string attribute) {
            var currentController = (helper.ViewContext.RouteData.Values["controller"] ?? string.Empty).ToString ().UnDash ();
            var currentAction = (helper.ViewContext.RouteData.Values["action"] ?? string.Empty).ToString ().UnDash ();
            var splitValue = value.Split (';');
            var splicController = controller.Split (';');

            var hasController = splicController.Contains (currentController); //controller.Equals(currentController, StringComparison.OrdinalIgnoreCase); //
            var hasAction = splitValue.Contains (currentAction);

            if (string.IsNullOrEmpty (value)) {
                hasAction = true;
            }

            return hasAction && hasController ? new HtmlString (attribute) : new HtmlString (string.Empty);
        }
        public static void RenderPartialIf (this IHtmlHelper htmlHelper, string partialViewName, bool condition) {

            if (!condition)
                return;

            htmlHelper.RenderPartialAsync (partialViewName).GetAwaiter ().GetResult ();
        }
    }

}