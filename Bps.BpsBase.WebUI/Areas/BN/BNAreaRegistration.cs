using System.Web.Mvc;

namespace Bps.BpsBase.WebUI.Areas.BN
{
    public class BNAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BN";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BN_default",
                "BN/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}