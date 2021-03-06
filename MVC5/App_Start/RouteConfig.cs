﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //url: "{controller}/{action}.php/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            //, constraints: new { id = @"\d+" });
            /*
            routes.MapRoute(
                name: "DefaultIndex",
                url: "",
                //url: "{controller}/{action}.php/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                }
            );
            */

        }
    }
}
