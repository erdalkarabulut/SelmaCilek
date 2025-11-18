using System.Web;
using System.Web.Mvc;

namespace Bps.BpsBase.WebUI.Controllers
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = httpContext.Session;
            if (session["SirketId"] != null || session["UserKod"] != null || 
                session["MenuTag"] != null || session["FirstName"] != null ||
                session["LastName"] != null || session["Email"] != null ||
                session["DilKod"] != null || session["KaynakKod"] != null)
            {
                return true;
            }

            httpContext.Response.Redirect("../GN/Login/Login");
            return false;

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}