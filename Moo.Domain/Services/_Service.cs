using Moo.Domain.Auth;

namespace Moo.Domain.Services
{
    public abstract class Service
    {
        protected int GetCurrentUserId()
        {
            var userContext = System.Web.HttpContext.Current.User as CustomPrincipal;
            return userContext.UserId;
        }
    }
}
