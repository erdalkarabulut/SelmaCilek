using System.Web.Mvc;

namespace Bps.BpsBase.WebUI.Areas.KS
{
    public class KSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KS_default",
                "KS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}