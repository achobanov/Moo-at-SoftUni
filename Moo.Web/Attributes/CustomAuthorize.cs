using System;
using System.Web.Mvc;
using System.Web.Routing;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public class CustomAuthorize : AuthorizeAttribute
{
    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        if (!filterContext.HttpContext.Request.IsAuthenticated)
        {
            filterContext.Result = new RedirectToRouteResult(
                 new RouteValueDictionary
                 {
                    { "controller", "Account" },
                    { "action", "Login" },
                    { "returnUrl", filterContext.HttpContext.Request.Url.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped) }
                 });
        }
        else
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}