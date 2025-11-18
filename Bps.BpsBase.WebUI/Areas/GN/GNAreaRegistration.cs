using System.Web.Mvc;

namespace Bps.BpsBase.WebUI.Areas.GN
{
    public class GNAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GN";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GN_default",
                "GN/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}