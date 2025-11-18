using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bps.Core.Web.Session;

namespace Bps.Core.Web.Authorization
{
    public class AuthorizeSession : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            bool _userLoggedIn = !string.IsNullOrEmpty(httpContext.Session.SessionID);
            var sirketId = SessionHelper.SirketId;
            var userId = SessionHelper.UserId;
            var userKod = SessionHelper.UserKod;
            var firstName = SessionHelper.FirstName;
            var lastName = SessionHelper.LastName;
            var projeKod = SessionHelper.ProjeKod;
            var menuTag = SessionHelper.MenuTag;
            var email = SessionHelper.Email;
            var dilKod = SessionHelper.DilKod;
            var kaynakKod = SessionHelper.KaynakKod;
            var role = SessionHelper.Role;
            var depertman = SessionHelper.Depertman;
            if (_userLoggedIn && (
                (sirketId == null) || userId == null ||
                string.IsNullOrEmpty(userKod) || string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                (menuTag == null) || string.IsNullOrEmpty(dilKod) ||
                kaynakKod == null || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(email)))
            {
                //if (httpContext.Session != null) httpContext.Session.Abandon();
                //httpContext.Response.Redirect("~/User/Login");
                //return false;

                if (httpContext.Session != null) httpContext.Session.Abandon();
                if (httpContext.Request.IsAjaxRequest())
                {
                    httpContext.Response.AddHeader("LOGIN_REQUIRED", "1");
                }
                return false;
            }
            //return base.AuthorizeCore(httpContext);
            return true;
        }
        
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                var values =
                    filterContext.RequestContext.HttpContext.Request.QueryString.AllKeys.ToDictionary(allKey => allKey,
                        allKey => filterContext.RequestContext.HttpContext.Request.QueryString[allKey]);
                foreach (
                    var allKey in
                    filterContext.RequestContext.HttpContext.Request.Form.AllKeys.Where(
                        allKey => !values.ContainsKey(allKey)))
                {
                    values.Add(allKey, filterContext.RequestContext.HttpContext.Request.Form[allKey]);
                }

                string returnUrl = filterContext.HttpContext.Request.Url.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped);
                bool queryStringPresent = filterContext.HttpContext.Request.QueryString.Count > 0;
                if (queryStringPresent || filterContext.HttpContext.Request.Form.Count > 0)
                    returnUrl += '?' + filterContext.HttpContext.Request.QueryString.ToString();
                if (queryStringPresent)
                    returnUrl += '&';
                returnUrl += filterContext.HttpContext.Request.Form;
                filterContext.HttpContext.Response.StatusCode = 900;
                filterContext.Result = new EmptyResult();

                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}