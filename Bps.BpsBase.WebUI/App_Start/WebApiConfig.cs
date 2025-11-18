using System.Web.Http;
using System.Web.Http.Cors;

namespace Bps.BpsBase.WebUI {

    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            var enableCorsAttr = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*") { SupportsCredentials = true };
            config.EnableCors(enableCorsAttr);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

}
