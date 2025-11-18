using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.Core.CrossCuttingConcerns.Security.Web;
using Bps.Core.Response;
using Bps.Core.Web.Binders;
using Bps.Core.Web.Session;
using DevExpress.Web.Demos.Models;
using DevExpress.Web.Mvc;

namespace Bps.BpsBase.WebUI
{
    public class MvcApplication : HttpApplication
    {
        private readonly ISirketService _sirketService = InstanceFactory.GetInstance<ISirketService>();
        private readonly IGnkullService _gnkullService = InstanceFactory.GetInstance<IGnkullService>();
        
        private void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
                new[] { "Bps.BpsBase.WebUI.Controllers" }
            );

        }

        protected void Application_Start()
        {
            //DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.v20_1;
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.DefaultBinder = new DevExpressEditorsBinder();
            //ModelBinders.Binders.Add(typeof(DateTime), new DateTimeBinder());
            //ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeBinder());
            //ModelBinders.Binders.Add(typeof(TimeSpan), new TimeSpanBinder());
            //ModelBinders.Binders.Add(typeof(TimeSpan?), new TimeSpanBinder());

            DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(CallbackError);

            #region Asp.Net Web Forms

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            #endregion

        }

        void CallbackError(object sender, EventArgs e)
        {
            // Logging exceptions occur on callback events of DevExpress ASP.NET MVC controls. 
            // To learn more, see http://www.devexpress.com/Support/Center/Example/Details/E4588
            var exception = HttpContext.Current.Server.GetLastError();

            DevExpress.Web.ASPxWebControl.SetCallbackErrorMessage(exception.Message);
        }
        
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];
            if (cookie != null && cookie.Value != null)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
            }
        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            if (Context.Handler is IRequiresSessionState)
            {
                var global = SessionHelper.ConvertSessiontoGlobal();
                if (global.SirketId != null && Session["Theme"] != null)
                {
                    if (!string.IsNullOrEmpty(Utils.CurrentTheme))
                    {
                        if (Session["Theme"].ToString() != "BlackGlass" && Utils.CurrentTheme == "BlackGlass")
                        {
                            var grSirket = _sirketService.Ncch_GetKarsiSirket_Log(global);
                            if (grSirket.Status == ResponseStatusEnum.OK && grSirket.Nesne != null)
                            {
                                Session["Theme"] = Utils.CurrentTheme;
                                HttpContext.Current.Session["SirketId"] = grSirket.Nesne.Id;
                                HttpContext.Current.Session["KarsiSirketId"] = grSirket.Nesne.KARSIS;
                                HttpContext.Current.Session["SirketType"] = false;
                                //HttpContext.Current.Response.Redirect("~/Dashboard/Index");
                            }
                        }
                        else if (Session["Theme"].ToString() == "BlackGlass" && Utils.CurrentTheme != "BlackGlass")
                        {
                            var grSirket = _sirketService.Ncch_GetKarsiSirket_Log(global);
                            if (grSirket.Status == ResponseStatusEnum.OK && grSirket.Nesne != null)
                            {
                                Session["Theme"] = Utils.CurrentTheme;
                                UpdateKullTheme(global.UserKod, Utils.CurrentTheme);
                                HttpContext.Current.Session["SirketId"] = grSirket.Nesne.Id;
                                HttpContext.Current.Session["KarsiSirketId"] = grSirket.Nesne.KARSIS;
                                HttpContext.Current.Session["SirketType"] = true;
                                //HttpContext.Current.Response.Redirect("~/Dashboard/Index");
                            }
                        }
                        else if (Session["Theme"].ToString() != Utils.CurrentTheme)
                        {
                            Session["Theme"] = Utils.CurrentTheme;
                            HttpContext.Current.Session["SirketType"] = true;
                            UpdateKullTheme(global.UserKod, Utils.CurrentTheme);
                        }
                    }
                }
                else
                {
                    Session["Theme"] = "Metropolis";
                }
                DevExpressHelper.Theme = Session["Theme"].ToString();
            }
            else
            {
                DevExpressHelper.Theme = Utils.CurrentTheme;
            }

            DevExpress.Web.ASPxWebControl.GlobalAccessibilityCompliant = true;
            Utils.ResolveThemeParametes();
            if (DevExpressHelper.IsCallback)
                Utils.RegisterCurrentMvcDemoOnCallback();

            if (Utils.IsAccessibilityDemo)
                DevExpress.Web.ASPxWebControl.GlobalAccessibilityCompliant = true;
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            //try
            //{
            //    var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            //    if (authCookie == null)
            //    {
            //        return;
            //    }

            //    var encTicket = authCookie.Value;
            //    if (String.IsNullOrEmpty(encTicket))
            //    {
            //        return;
            //    }

            //    var ticket = FormsAuthentication.Decrypt(encTicket);

            //    var securityUtlities = new SecurityUtilities();
            //    var identity = securityUtlities.FormsAuthTicketToIdentity(ticket);
            //    var principal = new GenericPrincipal(identity, identity.Roles);

            //    //HttpContext.Current.User = principal;
            //    Thread.CurrentPrincipal = principal;
            //}
            //catch (Exception)
            //{

            //}
            if (HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Contains("~/api"))
            {
                HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
            }
        }

        StandardResponse<bool> UpdateKullTheme(string userKod, string theme)
        {
            var sonuc = new StandardResponse<bool>();
            try
            {
                var global = SessionHelper.ConvertSessiontoGlobal();
                var kullResponse = _gnkullService.Cch_GetByUserKod_NLog(userKod, global);
                var kulEntity = kullResponse.Nesne;
                kulEntity.GNTHEM = theme;
                var updateResponse = _gnkullService.Ncch_Update_Log(kulEntity, kulEntity, global);
                sonuc.Status = updateResponse.Status;
                sonuc.Nesne = updateResponse.Status == ResponseStatusEnum.OK;
            }
            catch (Exception e)
            {
                sonuc.Nesne = false;
                sonuc.Status = ResponseStatusEnum.ERROR;
            }
            return sonuc;
        }
    }
}