using System.Web.Mvc;

namespace Bps.BpsBase.WebUI.Areas.IK
{
    public class IKAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IK";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "IK_default",
                "IK/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}