using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace netfwMVCBasic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Necessary to enable attribute-routing.
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "FooBar",
                url: "{controller}/{action}/{foo}/{bar}"
            );

            routes.MapRoute(
                name: "FixedRoute",
                url: "Users/Here/{id}",
                defaults: new { controller = "Whatever", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
