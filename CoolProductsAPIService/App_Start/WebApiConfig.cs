using CoolProductsAPIService.Models;
using System.Web.Http;
//using System.Web.Http.Cors;

namespace CoolProductsAPIService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Add(new ProductCSVFormatter());


            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",

                defaults: new { controller = "coolproducts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/v2/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "coolproductsv2" }
            );
        }
    }
}
