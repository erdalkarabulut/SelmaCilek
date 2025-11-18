using System.Web.Mvc;

namespace Bps.BpsBase.WebAPI.Areas.ST
{
    public class STAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ST";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ST_default",
                "ST/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}